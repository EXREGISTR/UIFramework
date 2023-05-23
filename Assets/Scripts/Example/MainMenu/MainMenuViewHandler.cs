using System.Threading;
using UIFramework;

namespace Example {
	public class MainMenuViewHandler : ViewHandler, IPersistentViewHandler {
		private readonly CancellationTokenSource cts = new();
		
		public override void OnShow() {
			if (string.IsNullOrWhiteSpace(PlayerData.Instance.Name)) {
				ShowRegistrationWindow();
			}
		}

		private void ShowRegistrationWindow() {
			uiService.Show(new RegistrationViewHandler());
		}

		public void Play() {
			if (!string.IsNullOrWhiteSpace(PlayerData.Instance.Name)) {
				uiService.ShowAndCloseAsync(new InformationViewHandler("No game ((999(("), 3f, cts.Token);
			} else {
				ShowRegistrationWindow();
			}
		}

		public override void Dispose() => cts.Cancel();
	}
}