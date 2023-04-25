using UIFramevork;
using UnityEngine;

namespace Example {
	public class PlayerViewHandler : ViewHandler<PlayerScreen>, IPersistentViewHandler {
		private readonly UserData user = UserData.Get();
		private const int STOIMOST_SMENI_NIKA = 250;

		public override void OnShow() {
			screen.UpdateMoneyAmount(user.Money);
			if (user.Name != null) {
				screen.ChangeNameVisibility(false);
			}
		}

		public void Play() {
			var message = user.Name == null ? "Эу чувак, ноунеймов не принимаем!" : "а игры то нет, ухадите";
			uiService.Show(new DialogViewHandler(message));
		}
		
		public void StartSetupName() {
			if (user.Money < STOIMOST_SMENI_NIKA) {
				uiService.Show(new DialogViewHandler("Not enough money to change name!"));
				return;
			}

			uiService.Show(new SetupNameViewHandler(() => {
				user.Money -= STOIMOST_SMENI_NIKA;
				screen.UpdateMoneyAmount(user.Money);
			}));
		}

		public void AddMoney() {
			if (user.Money >= 500) return;
			
			user.Money = Mathf.Clamp(user.Money + Random.Range(50, 100), 0, 500);
			screen.UpdateMoneyAmount(user.Money);
		}
	}
}