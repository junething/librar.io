
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Driver;
using shortid;
using System;

namespace LibrarioAPI.Models {
	public class User {
		//[BsonId]
		//[BsonRepresentation (BsonType.ObjectId)]
		[BsonId (IdGenerator = typeof (IdGenerator))]
		public string Id { get; set; }

		[BsonElement ("username")]
		public string Username { get; set; }
		[BsonElement ("created")]
		public DateTime Created { get; set; }
		[BsonElement ("email")]
		public string Email { get; set; }
		[BsonElement ("password")]
		public string Password { get; set; }
		[BsonElement ("salt")]
		public string Salt { get; set; }

}

