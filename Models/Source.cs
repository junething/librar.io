
using MongoDB.Bson;

using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Driver;
using shortid;
namespace LibrarioAPI.Models {
	public class Source {
		[BsonElement ("url")]
		public string URL { get; set; }
		[BsonElement ("whoCanAccess")]
		public string[] WhoCanAccess;
		public Source(string url, string[] whoCanAcess)
		{
			URL = url;
			WhoCanAccess = whoCanAcess;
		}
	}
}

