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
        readonly SessionTokenService sessionTokenService;
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        public UserService(ILibrarioDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UsersCollectionName);
            sessionTokenService = new SessionTokenService(settings);
        }

        public User CreateFrom(UserSignup _user)
        {
            User user = new User(_user);
            _users.InsertOne(user);
            return user;
        }
        public string Login(Credentials creds) {
            User user;
            Console.WriteLine(creds.Cred + " and " + creds.Password);
            if(creds.Cred.Contains('@'))
                user = _users.Find<User>(_user => _user.Email == creds.Cred).FirstOrDefault();
            else
                user = _users.Find<User>(_user => _user.Username == creds.Cred).FirstOrDefault();
            if (Crypto.VerifyPassword(creds.Password, user.Password)) {
                string token = sessionTokenService.Create(user).Tok;
                return token;
            } else {
                throw new Crypto.InvalidCredentials();
            }
            
        }
    }

}