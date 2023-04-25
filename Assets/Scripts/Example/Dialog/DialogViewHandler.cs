using UIFramevork;

namespace Example {
	public class DialogViewHandler : ViewHandler<DialogScreen>, IOneTimeHandler {
		private readonly string message;
		
		public DialogViewHandler(string message) {
			this.message = message;
		}

		protected override void OnScreenBinded() {
			screen.SetMessage(message);
		}

		public void Close() {
			uiService.Close<DialogViewHandler>();
		}
	}
}