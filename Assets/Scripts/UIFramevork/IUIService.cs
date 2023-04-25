using System;

namespace UIFramevork {
	public interface IUIService : IDisposable {
		public void Initialize(IScreensContainer container);
		public void Show<THandler>() where THandler : IPersistentViewHandler;
		public void Show<THandler>(THandler handler) where THandler : IOneTimeHandler;
		public void Close<THandler>() where THandler : IViewHandler;
		public void BindHandler<THandler>(THandler handler) where THandler : IPersistentViewHandler;
	}
}