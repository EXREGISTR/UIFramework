using TMPro;
using UIFramevork;
using UnityEngine;

namespace Example {
	public class InformationScreen : Screen<InformationViewHandler> {
		[SerializeField] private TMP_Text messageText;
		
		protected override void OnHandlerBinded() {
			messageText.text = handler.Message;
		}

		protected override void OnUnbindHandler() {
			messageText.text = null;
		}
	}
}