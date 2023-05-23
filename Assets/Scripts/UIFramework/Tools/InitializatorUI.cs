using UnityEngine;

namespace UIFramework {
	public abstract class InitializatorUI : MonoBehaviour {
		[SerializeField] private ScreenContainer container;

		private readonly IUIService service = new UIService();
		
		private void Start() {
			service.Initialize(container);
			
			Initialize(service);
		}
		
		private void OnDisable() => service.Dispose();
		
		protected abstract void Initialize(IUIService service);
	}
}