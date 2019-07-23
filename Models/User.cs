
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Driver;
using shortid;
using System;
using LibrarioAPI.Services;
namespace LibrarioAPI.Models {
	public class User {
		public User(UserSignup _user) {
			Username = _user.Username;
			Email = _user.Email;

            Password = Crypto.HashPassword(_user.Password);
            Created = DateTime.Now;
		}
		[BsonId]
		[BsonRepresentation (BsonType.ObjectId)]
		//[BsonId (IdGenerator = typeof (IdGenerator))]
		public string Id { get; set; }

		[BsonElement ("username")]
		public string Username { get; set; }
		[BsonElement ("created")]
		public DateTime Created { get; set; }
		[BsonElement ("email")]
		public string Email { get; set; }
		[BsonElement ("password")]
		public string Password { get; set; }
	}
}

