using System;
using System.Collections.Generic;

namespace Framework.IOC
{
	public class IOCContainer
	{
		private readonly Dictionary<Type, object> _instances = new Dictionary<Type, object>();

		public void Register<T>(T instance)
		{
			var key = typeof(T);

			if (_instances.ContainsKey(key))
			{
				_instances[key] = instance;
			}
			else
			{
				_instances.Add(key, instance);
			}
		}

		public T Get<T>() where T : class
		{
			var key = typeof(T);
			if (_instances.ContainsKey(key))
			{
				return _instances[key] as T;
			}
			return null;
		}
	}
}
