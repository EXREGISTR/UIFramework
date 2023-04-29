using System;
using UIFramevork;

namespace Example {
	public class RegistrationViewHandler : DialogViewHandler<RegistrationViewHandler> {
		private static readonly Guid password = Guid.NewGuid();
		
		public ProtectedReactiveProperty<bool> State { get; }
		
		private string enteredName;

		public RegistrationViewHandler() {
			State = new ProtectedReactiveProperty<bool>(password);
		}
		
		public void OnEnterName(string name) {
			// else some validate
			State.SetValue(!string.IsNullOrWhiteSpace(name), password); 
			enteredName = name;
		}

		public void Save() {
			if (!State) return;

			PlayerData.Instance.Name = enteredName;
			Close();
		}
	}
}