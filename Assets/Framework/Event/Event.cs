using System;

namespace Framework.Event
{
	public class Event<T> where T : Event<T>
	{
		private static Action _onEvent; // 必须是泛型不然这个值会重复

		public static void Register(Action onEvent)
		{
			_onEvent += onEvent;
		}

		public static void UnRegister(Action onEvent)
		{
			_onEvent -= onEvent;
		}

		public static void Trigger()
		{
			_onEvent?.Invoke();
		}
	}
}
