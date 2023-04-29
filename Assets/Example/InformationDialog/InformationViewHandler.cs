using UIFramevork;

namespace Example {
	public class InformationViewHandler : DialogViewHandler<InformationViewHandler> {
		public string Message { get; }
		
		public InformationViewHandler(string message) {
			Message = message;
		}
	}
}