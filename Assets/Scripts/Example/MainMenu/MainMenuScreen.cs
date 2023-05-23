using UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace Example {
	public class MainMenuScreen : Screen<MainMenuViewHandler> {
		[SerializeField] private Button playButton;
		
		protected override void OnHandlerBinded() {
			playButton.onClick.AddListener(handler.Play);
		}

		protected override void OnUnbindHandler() {
			playButton.onClick.RemoveAllListeners();
		}
	}
}