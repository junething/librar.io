
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Driver;
using shortid;
using System;
using LibrarioAPI.Services;
namespace LibrarioAPI.Models {
	public class Credentials {
		public string Cred { get; set; }
		public string Password { get; set; }
	}
}

