
using MongoDB.Bson;

using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Driver;
using shortid;
namespace LibrarioAPI.Models {
	public class Item {
		//[BsonId]
		//[BsonRepresentation (BsonType.ObjectId)]
		[BsonId (IdGenerator = typeof (IdGenerator))]
		public string Id { get; set; }

		[BsonElement ("Title")]
		public string Title { get; set; }
		[BsonElement ("Creator")]
		public string Creator { get; set; }
		[BsonElement ("Sources")]
		/*//public BsonDocument Sources {
			get => sourcesBson;
			set {
				sourcesBson = value;
				SourcesDict = value.ToDictionary ();
			}
		}*/
		public Dictionary<string, Source> Sources;
	}
}

