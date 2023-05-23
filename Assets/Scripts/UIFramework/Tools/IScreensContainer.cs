using System.Collections.Generic;

namespace UIFramework {
	public interface IScreensContainer {
		public IReadOnlyCollection<IScreen> GetScreens();
	}
}