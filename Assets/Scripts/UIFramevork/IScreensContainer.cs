using System.Collections.Generic;

namespace UIFramevork {
	public interface IScreensContainer {
		public IReadOnlyCollection<IScreen> GetScreens();
	}
}