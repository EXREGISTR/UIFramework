using System;

namespace UIFramevork {
	public interface IViewHandler : IDisposable {
		public void InjectUIService(IUIService uiService);
		public void BindScreen(IScreen screen);
		public void OnShow();
		public void OnClose();
	}
}