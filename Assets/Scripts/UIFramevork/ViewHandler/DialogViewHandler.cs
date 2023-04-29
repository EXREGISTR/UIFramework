using System;

namespace UIFramevork {
	public abstract class DialogViewHandler<T> : ViewHandler, IOneTimeHandler where T: DialogViewHandler<T> {
		private Action onClose;
		protected DialogViewHandler(Action onClose = null) => this.onClose = onClose;

		public void Close() {
			onClose?.Invoke();
			uiService.Close<T>();
		}

		public override void Dispose() => onClose = null;
	}
}