using System;
using System.Text.RegularExpressions;
using UIFramevork;

namespace Example {
	public class SetupNameViewHandler : ViewHandler<SetupNameScreen>, IOneShotViewHandler {
		private readonly UserModel user = UserModel.Get();
		private readonly Action onNameSetted;
		private string name;

		public SetupNameViewHandler(Action onNameSetted) {
			this.onNameSetted = onNameSetted;
		}

		public void OnNameChanged(string name) {
			bool result = !string.IsNullOrWhiteSpace(name) && 
			              Regex.IsMatch(name, "^[a-z0-9_]+$", RegexOptions.IgnoreCase);
			
			screen.SetState(result);
			if (result) this.name = name;
		}
		
		public void OnOkayClicked() {
			user.Name = name;
			onNameSetted?.Invoke();
			uiService.Close<SetupNameViewHandler>();
		}
	}
}