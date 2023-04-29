using UIFramevork;

namespace Example {
	public class InformationViewHandler : ViewHandler, IOneTimeHandler {
		public string Message { get; }
		
		public InformationViewHandler(string message) {
			Message = message;
		}
	}
}