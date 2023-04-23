using UIFramevork;

namespace Example {
	public class GameUIInitializator : InitializatorUI {
		protected override void Initialize(IUIService service) {
			service.BindHandler(new PlayerViewHandler());
			service.Show<PlayerViewHandler>();
		}
	}
}