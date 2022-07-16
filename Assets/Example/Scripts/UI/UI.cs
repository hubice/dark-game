using Example.Scripts.Event;
using UnityEngine;

namespace Example.Scripts.UI
{
	public class UI : MonoBehaviour
	{
		private void Awake()
		{
			GameEndEvent.Register(OnGameEndEvent);
		}

		private void OnGameEndEvent()
		{
			transform.Find("Canvas/GameEndPanel").gameObject.SetActive(true);
		}

		private void OnDestroy()
		{
			GameEndEvent.UnRegister(OnGameEndEvent);
		}
	}
}
