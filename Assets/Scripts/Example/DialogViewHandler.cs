using UIFramevork;

namespace Example {
	public class DialogViewHandler : ViewHandler<DialogScreen>, IOneShotViewHandler {
		private readonly string message;
		
		public DialogViewHandler(string message) {
			this.message = message;
		}

		protected override void OnScreenBinded() {
			screen.SetMessage(message);
		}

		public void OnOkayClicked() {
			uiService.Close<DialogViewHandler>();
		}
	}
}