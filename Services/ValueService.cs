using LibrarioAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace LibrarioAPI.Services
{
    public class ValueService
    {
        private readonly IMongoCollection<Value> _values;

        public ValueService(ILibrarioDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _values = database.GetCollection<Value>(settings.ValuesCollectionName);
        }

        public List<Value> Get() =>
            _values.Find(value => true).ToList();

        public Value Get(string id) =>
            _values.Find<Value>(value => value.Id == id).FirstOrDefault();

        public Value Create(Value value)
        {
            _values.InsertOne(value);
            return value;
        }

        public void Update(string id, Value valueIn) =>
            _values.ReplaceOne(value => value.Id == id, valueIn);

        public void Remove(Value valueIn) =>
            _values.DeleteOne(value => value.Id == valueIn.Id);

        public void Remove(string id) => 
            _values.DeleteOne(value => value.Id == id);
    }
}