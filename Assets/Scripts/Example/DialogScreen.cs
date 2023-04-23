using TMPro;
using UIFramevork;
using UnityEngine;
using UnityEngine.UI;

namespace Example {
	public class DialogScreen : Screen<DialogViewHandler> {
		[SerializeField] private Button okayButton;
		[SerializeField] private TMP_Text messageText;

		protected override void OnHandlerBinded() {
			okayButton.onClick.AddListener(handler.OnOkayClicked);
		}

		public override void Dispose() {
			messageText.text = null;
			okayButton.onClick.RemoveAllListeners();
		}

		public void SetMessage(string message) => messageText.text = message;
	}
}