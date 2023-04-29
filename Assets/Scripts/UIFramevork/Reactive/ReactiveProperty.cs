using System;

namespace UIFramevork {
	public class ReactiveProperty<T> where T: struct {
		private T value;

		public T Value {
			get => value;
			set {
				if (this.value.Equals(value)) return;
				this.value = value;
				Changed?.Invoke(value);
			}
		}

		public event Action<T> Changed;

		public ReactiveProperty(T value = default) => this.value = value;

		public static implicit operator T(ReactiveProperty<T> property) => property.value;
	}
}