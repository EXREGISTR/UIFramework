﻿using System;
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
				throw new InvalidCastException($"Handler {handler} is not type {typeof(TViewHandler).FullName}!");
			}

			if (this.handler != null) {
				if (ReferenceEquals(this.handler, handler)) {
					Debug.LogWarning($"You try to set similar handler {handler} for screen {ToString()}", this);
					return;
				}
				
				this.handler.Dispose(); 
				OnUnbindHandler();
			}
			
			this.handler = castedHandler;
			OnHandlerBinded();
		}
		
		protected virtual void OnHandlerBinded() { }
		protected virtual void OnUnbindHandler() { }
		public virtual void Dispose() { }
	}
}