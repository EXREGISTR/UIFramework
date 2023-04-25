﻿using System;
using UnityEngine;

namespace UIFramevork {
	public abstract class ViewHandler<TScreen> : IViewHandler where TScreen : IScreen {
		protected TScreen screen;
		protected IUIService uiService;

		public void InjectUIService(IUIService uiService) => this.uiService = uiService;
	
		public void BindScreen(IScreen screen) {
			if (screen is not TScreen castedScreen) {
				throw new InvalidCastException($"Screen {screen} is not type {typeof(TScreen).FullName}!");
			}

			if (this.screen != null) {
				if (ReferenceEquals(this.screen, screen)) {
					Debug.LogWarning($"You try to set similar screen {screen} for handler {ToString()}");
					return;
				}
				
				this.screen.Dispose();
				Dispose();
			}
		
			this.screen = castedScreen;
			OnScreenBinded();
		}
		
		protected virtual void OnScreenBinded() { }
		
		public virtual void OnShow() { }
		public virtual void OnClose() { }
		public virtual void Dispose() { }
	}
}