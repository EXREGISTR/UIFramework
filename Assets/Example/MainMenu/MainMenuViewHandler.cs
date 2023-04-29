using UIFramevork;

namespace Example {
	public class MainMenuViewHandler : ViewHandler, IPersistentViewHandler {
		public override void OnShow() {
			if (string.IsNullOrWhiteSpace(PlayerData.Instance.Name)) {
				ShowRegistrationWindow();
			}
		}

		private void ShowRegistrationWindow() {
			uiService.Show(new RegistrationViewHandler());
		}

		public void Play() {
			if (string.IsNullOrWhiteSpace(PlayerData.Instance.Name)) {
				ShowRegistrationWindow();
				return;
			}
			
			uiService.Show(new InformationViewHandler("No game ((999(("));
		}
	}
}