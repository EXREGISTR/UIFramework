using TMPro;
using UIFramevork;
using UnityEngine;
using UnityEngine.UI;

namespace Example {
	public class RegistrationScreen : Screen<RegistrationViewHandler> {
		[SerializeField] private TMP_InputField nameField;
		[SerializeField] private Button okButton;
		[SerializeField] private Button closeButton;

		[ColorUsage(true)]
		[SerializeField] private Color succesedNameColor;
		
		[ColorUsage(true)]
		[SerializeField] private Color errorNameColor;

		protected override void OnHandlerBinded() {
			nameField.onValueChanged.AddListener(handler.OnEnterName);
			okButton.onClick.AddListener(handler.Save);
			closeButton.onClick.AddListener(handler.Close);
			
			handler.State.Changed += OnStateChanged;
		}
		
		protected override void OnUnbindHandler() {
			nameField.onValueChanged.RemoveAllListeners();
			okButton.onClick.RemoveAllListeners();
			closeButton.onClick.RemoveAllListeners();

			handler.State.Changed -= OnStateChanged;
		}
		
		private void OnStateChanged(in bool value) {
			okButton.interactable = value;
			var color = value ? succesedNameColor : errorNameColor;
			nameField.textComponent.color = color;
		}
	}
}