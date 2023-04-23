﻿using System.Collections.Generic;
using UnityEngine;

namespace UIFramevork {
	public class ScreenContainer : MonoBehaviour, IScreensContainer {
		private IScreen[] screens;
		
		private void Awake() {
			screens = GetComponentsInChildren<IScreen>(true);
		}

		public IReadOnlyCollection<IScreen> GetScreens() => screens;
	}
}