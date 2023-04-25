using System;
using System.Text.RegularExpressions;
using UIFramevork;

namespace Example {
	public class SetupNameViewHandler : ViewHandler<SetupNameScreen>, IOneTimeHandler {
		private readonly UserData user = UserData.Get();
		private readonly SetupNameModel model = new();

		public SetupNameViewHandler(Action onNameSetted) {
			model.OnNameSetted = onNameSetted;
		}

		public void OnNameChanged(string name) {
			var lastResult = model.Result;
			model.Result = !string.IsNullOrWhiteSpace(name) && 
			               Regex.IsMatch(name, "^[a-z0-9_]+$", RegexOptions.IgnoreCase);
			
			if (model.Result != lastResult) screen.SetState(model.Result);
			if (model.Result) model.Name = name;
		}
		
		public void OnOkayClicked() {
			if (!model.Result) return;
			
			user.Name = model.Name;
			model.OnNameSetted?.Invoke();
			uiService.Close<SetupNameViewHandler>();
		}
	}
}