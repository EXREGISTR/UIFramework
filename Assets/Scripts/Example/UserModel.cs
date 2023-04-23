namespace Example {
	public class UserModel {
		private static UserModel instance;
		private const string FILE_PATH = "path";
		
		public string Name { get; set; }
		public int Money { get; set; }

		private UserModel() { }

		public static UserModel Get() {
			return instance ??= new UserModel();
		}
		
		public void Save() { }
	}
}