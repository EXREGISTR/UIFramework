using System;
using UnityEngine;

namespace UIFramevork {
	public abstract class Screen<TViewHandler> : MonoBehaviour, IScreen where TViewHandler: IViewHandler {
		public Type HandlerType { get; } = typeof(TViewHandler);
		protected TViewHandler handler;
		
		protected virtual void OnDestroy() => Dispose();

		public void Show() {
			gameObject.SetActive(true);
			handler.OnShow();
		}

		public void Close() {
			handler.OnClose();
			gameObject.SetActive(false);
		}
		
		public void BindHandler(IViewHandler handler) {
			if (handler is not TViewHandler castedHandler) {
				throw new InvalidCastException();
			}

			if (this.handler != null) {
				if (ReferenceEquals(this.handler, handler)) return;
				this.handler.Dispose(); 
				Dispose();
			}
			
			this.handler = castedHandler;
			OnHandlerBinded();
		}

		protected virtual void OnHandlerBinded() { }
		public virtual void Dispose() { }
	}
}