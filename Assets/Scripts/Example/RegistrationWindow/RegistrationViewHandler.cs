using System;
using System.Text.RegularExpressions;
using UIFramevork;

namespace Example {
	public class RegistrationViewHandler : ViewHandler, IOneTimeHandler {
		private static readonly Guid propertyPassword = Guid.NewGuid();
		
		public ProtectedReactiveProperty<bool> State { get; }
		
		private string enteredName;

		public RegistrationViewHandler() {
			State = new ProtectedReactiveProperty<bool>(propertyPassword);
		}
		
		public void OnEnterName(string name) {
			var result = !string.IsNullOrWhiteSpace(name) && 
			             Regex.IsMatch(name, "^[a-z0-9_]+$", RegexOptions.IgnoreCase);
			State.SetValue(result, propertyPassword);
			enteredName = name;
		}

		public void Save() {
			if (!State) return;

			PlayerData.Instance.Name = enteredName;
			Close();
		}

		public void Close() => uiService.Close<RegistrationViewHandler>();
	}
}