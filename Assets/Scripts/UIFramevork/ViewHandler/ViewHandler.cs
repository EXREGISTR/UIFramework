using JetBrains.Annotations;

namespace UIFramevork {
	public abstract class ViewHandler : IViewHandler {
		protected IUIService uiService;

		public void InjectUIService([NotNull] IUIService uiService) => this.uiService = uiService;

		public virtual void OnShow() { }
		public virtual void OnClose() { }
		public virtual void Dispose() { }
	}
}