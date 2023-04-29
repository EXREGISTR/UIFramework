using System;

namespace UIFramevork {
	public interface IScreen : IDisposable {
		public Type HandlerType { get; }
		
		public void Show();
		public void Hide();
		public void BindHandler(IViewHandler handler);
	}
}