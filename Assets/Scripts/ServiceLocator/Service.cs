using System;

namespace Services {
	public abstract class Service {
		private readonly Type serviceType;
		
		protected Service() {
			serviceType = GetType();
			Register();
		}
		
		~Service() => Unregister();
		
		protected void Register() => ServiceLocator.Register(this);
		protected void Unregister() => ServiceLocator.Unregister(this);
		internal Type GetServiceType() => serviceType;
		public override string ToString() => GetServiceType().ToString();
	}
}