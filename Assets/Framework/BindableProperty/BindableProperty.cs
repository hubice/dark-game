using System;

namespace Framework.BindableProperty
{
	public class BindableProperty<T>
	{
		private T _value = default(T);

		public Action<T> OnValueChanged;

		public T Value
		{
			get => _value;
			set
			{
				if (value.Equals(_value)) return;
				_value = value;
				OnValueChanged?.Invoke(value);
			}
		}
	}
}
