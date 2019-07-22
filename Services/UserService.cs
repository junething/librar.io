using LibrarioAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using BCrypt.Net;
using System;
namespace LibrarioAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public UserService(ILibrarioDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public List<User> Get() =>
            _users.Find(user => true).ToList();

        public User Get(string id) =>
            _users.Find<User>(user => user.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            user.Salt = Security.NewSalt(12);
            user.Password = Security.HashPassword(user.Password, user.Salt);
            user.Created = DateTime.Now;
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(User userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) => 
            _users.DeleteOne(user => user.Id == id);


    }

}