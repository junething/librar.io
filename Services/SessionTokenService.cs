using LibrarioAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LibrarioAPI.Services
{
    public class SessionTokenService
    {
        private readonly IMongoCollection<Token> _tokens;

        public SessionTokenService(ILibrarioDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tokens = database.GetCollection<Token>(settings.SessionTokensCollectionName);
        }

        public List<Token> Get() =>
            _tokens.Find(item => true).ToList();

        public Token Get(string id) =>
            _tokens.Find<Token>(item => item.Id == id).FirstOrDefault();

        public Token Create(User user)
        {
            Token token = new Token(user, Crypto.RandomString(32));
            var existing = _tokens.Find<Token>(tok => tok.User == user.Id).FirstOrDefault();
            if (existing != null)
                _tokens.DeleteOne(tok => tok.User == user.Id);
            _tokens.InsertOne(token);
        
            return token;
        }

        public void Update(string id, Token itemIn) =>
            _tokens.ReplaceOne(item => item.Id == id, itemIn);

        public void Remove(Token itemIn) =>
            _tokens.DeleteOne(item => item.Id == itemIn.Id);

        public void Remove(string id) => 
            _tokens.DeleteOne(item => item.Id == id);
    }
}