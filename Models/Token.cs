using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Driver;
using shortid;
namespace LibrarioAPI.Models {
	public class Token {
		public Token (User user, string token)
		{
			Tok = token;
			User = user.Id;
		}
		[BsonId]
		[BsonRepresentation (BsonType.ObjectId)]
		public string Id { get; set; }
		[BsonElement ("user")]
		public string User { get; set; }
		[BsonElement ("token")]
		public string Tok { get; set; }
		[BsonElement ("createdAt")]
		public System.DateTime DateTime { get; set; }
	}
}
