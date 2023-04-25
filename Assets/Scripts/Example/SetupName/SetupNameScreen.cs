using TMPro;
using UIFramevork;
using UnityEngine;
using UnityEngine.UI;

namespace Example {
	public class SetupNameScreen : Screen<SetupNameViewHandler> {
		[SerializeField] private TMP_InputField nameField;
		[SerializeField] private Button okButton;
		
		[ColorUsage(true)]
		[SerializeField] private Color succecedFieldColor;
		
		[ColorUsage(true)]
		[SerializeField] private Color errorFieldColor;

		protected override void OnHandlerBinded() {
			okButton.onClick.AddListener(handler.OnOkayClicked);
			nameField.onValueChanged.AddListener(handler.OnNameChanged);
			nameField.onEndEdit.AddListener(handler.OnNameChanged);
		}

		public override void Dispose() {
			okButton.onClick.RemoveAllListeners();
			nameField.onValueChanged.RemoveAllListeners();
			nameField.onEndEdit.RemoveAllListeners();
		}

		public void SetState(bool status) {
			okButton.interactable = status;
			var colorField = status ? succecedFieldColor : errorFieldColor;
			nameField.textComponent.color = colorField;
		}
	}
}