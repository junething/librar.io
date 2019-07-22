namespace LibrarioAPI.Models {
	public class LibrarioDatabaseSettings : ILibrarioDatabaseSettings {
		public string ItemsCollectionName { get; set; }
		public string ValuesCollectionName { get; set; }
		public string UsersCollectionName { get; set; }
		public string TempTokensCollectionName { get; set; }
		public string ConnectionString { get; set; }
		public string DatabaseName { get; set; }
	}

	public interface ILibrarioDatabaseSettings {
		string ItemsCollectionName { get; set; }
		string UsersCollectionName { get; set; }
		string TempTokensCollectionName { get; set; }
		string ValuesCollectionName { get; set; }
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }
	}
}
