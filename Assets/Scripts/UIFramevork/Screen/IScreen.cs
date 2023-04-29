using System;
using JetBrains.Annotations;

namespace UIFramevork {
	public interface IScreen : IDisposable {
		public Type HandlerType { get; }
		
		public void Show();
		public void Hide();
		public void BindHandler([NotNull] IViewHandler handler);
	}
}