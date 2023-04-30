using System;
using System.Threading;
using JetBrains.Annotations;

namespace UIFramevork {
	public interface IUIService : IDisposable {
		public void Initialize([NotNull] IScreensContainer container);
		public void Show<THandler>() where THandler : IPersistentViewHandler;
		public void Show<THandler>([NotNull] THandler handler) where THandler : IOneTimeHandler;
		public void ShowAsync<THandler>([NotNull] THandler handler, float lifeTimeInSeconds, CancellationToken token) 
			where THandler : IOneTimeHandler;
		public void Close<THandler>(bool showWarning = true) where THandler : IViewHandler;
		public void BindHandler<THandler>([NotNull] THandler handler) where THandler : IPersistentViewHandler;
	}
}