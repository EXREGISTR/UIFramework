using System;

namespace Example {
	public class PlayerData {
		public string Name { get; set; }

		private PlayerData() { }
		static PlayerData() => Load();
		
		private static PlayerData instance;
		public static PlayerData Instance {
			get {
				if (instance == null) throw new NullReferenceException();
				return instance;
			}
		}
		
		public static void Load(string name = null) {
			instance ??= new PlayerData();
		}
	}
}