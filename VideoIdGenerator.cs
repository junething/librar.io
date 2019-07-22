using System;
using MongoDB.Driver;
using MongoDB;
using MongoDB.Bson.Serialization;
using shortid;
namespace LibrarioAPI {
	public class IdGenerator : IIdGenerator {

		public object GenerateId (object container, object document)
		{

			return ShortId.Generate (true, false, 12);
		}

		public bool IsEmpty (object id)
		{
			return id == null || String.IsNullOrEmpty (id.ToString ());
		}
	}
}
