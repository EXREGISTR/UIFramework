using UnityEngine;

namespace Example {
	public class UserData {
		private static UserData instance;

		private string name;
		public string Name {
			get => name;
			set {
				name = value;
				SaveName();
			}
		}

		private int money;
		public int Money { 
			get => money;
			set {
				money = value;
				SaveMoney();
			}
		}

		private UserData() { }

		// here can be load from database/json
		public static UserData Get() {
			instance ??= new UserData {
				name = PlayerPrefs.GetString(nameof(name), null),
				money = PlayerPrefs.GetInt(nameof(money), 0)
			};

			return instance;
		}
		
		private void SaveName() {
			PlayerPrefs.SetString(nameof(name), name);
		}

		private void SaveMoney() {
			PlayerPrefs.SetInt(nameof(money), money);
		}
	}
}