using UnityEngine;

namespace Example {
	public class UserData {
		private static UserData instance;
		
		public string Name { get; set; }
		public int Money { get; set; }

		private UserData() { }

		// here can be load from database/json
		public static UserData Get() {
			instance ??= new UserData {
				Name = PlayerPrefs.GetString(nameof(Name)),
				Money = PlayerPrefs.GetInt(nameof(Money))
			};

			return instance;
		}

		public void Save() {
			PlayerPrefs.SetString(nameof(Name), Name);
			PlayerPrefs.SetInt(nameof(Money), Money);
		}
	}
}