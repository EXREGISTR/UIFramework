using System;
using System.Collections.Generic;

namespace Services {
	public static class ServiceLocator {
		private static readonly Dictionary<Type, Service> servicesMap = new(20);
		
		public static void Register(Service service, bool throwIfContains = true) {
			var key = service.GetServiceType();
			
			if (servicesMap.ContainsKey(key)) {
				if (throwIfContains) {
					throw new ServiceException($"Service by type {key} already registered!");
				} 
				
				servicesMap.Remove(key);
			}

			servicesMap[key] = service;
		}
		
		public static void Unregister(Service service) {
			var key = service.GetServiceType();
			servicesMap.Remove(key);
		}
		
		public static T GetService<T>() where T: Service {
			var key = typeof(T);
			if (!servicesMap.TryGetValue(key, out var service)) {
				throw new ServiceException($"Service of type {key} doesn't registered!");
			}
			
			return (T)service;
		}
	}

	internal class ServiceException : Exception {
		public ServiceException(string message) : base(message) { }
	}
}