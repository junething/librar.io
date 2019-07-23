
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Driver;
using shortid;
using System;

namespace LibrarioAPI.Models {
	public class UserSignup {
		[BsonElement ("username")]
		public string Username { get; set; }
		[BsonElement ("email")]
		public string Email { get; set; }
		[BsonElement ("password")]
		public string Password { get; set; }
	}
}

