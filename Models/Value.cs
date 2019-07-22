using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Driver;
using shortid;
namespace LibrarioAPI.Models {
	public class Value {
		public Value(string str)
		{
			Str = str;
		}
		//[BsonId]
		//[BsonRepresentation (BsonType.ObjectId)]
		[BsonId (IdGenerator = typeof (IdGenerator))]
		public string Id { get; set; }

		[BsonElement ("Str")]
		public string Str { get; set; }
	}
}
