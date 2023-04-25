using System;

namespace Example {
	public class SetupNameModel {
		public string Name { get; set; }
		public bool Result { get; set; }
		public Action OnNameSetted { get; set; } 
	}
}