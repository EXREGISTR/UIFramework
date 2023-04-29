namespace Example {
	public class PlayerData {
		public string Name { get; set; }

		private PlayerData() { }
		
		private static PlayerData instance;
		public static PlayerData Instance {
			get {
				instance ??= new PlayerData();
				return instance;
			}
		}
	}
}