using TMPro;
using UIFramevork;
using UnityEngine;
using UnityEngine.UI;

namespace Example {
	public class RegistrationScreen : Screen<RegistrationViewHandler> {
		[SerializeField] private TMP_InputField nameField;
		[SerializeField] private Button okButton;

		protected override void OnHandlerBinded() {
			nameField.onValueChanged.AddListener(handler.OnEnterName);
			okButton.onClick.AddListener(handler.Save);
			
			handler.State.Changed += OnStateChanged;
		}
		
		protected override void OnUnbindHandler() {
			nameField.onValueChanged.RemoveAllListeners();
			okButton.onClick.RemoveAllListeners();

			handler.State.Changed -= OnStateChanged;
		}
		
		private void OnStateChanged(in bool value) {
			okButton.interactable = value;
		}
	}
}