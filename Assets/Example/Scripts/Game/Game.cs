using Example.Scripts.Event;
using Framework.Architecture;
using UnityEngine;

namespace Example.Scripts.Game
{
	public class Game : MonoBehaviour
	{
		private void Awake()
		{
			GameStartEvent.Register(OnGameStartEvent);
		}

		private void OnGameStartEvent()
		{
			transform.Find("EnemyList").gameObject.SetActive(true);
		}

		private void OnDestroy()
		{
			GameStartEvent.UnRegister(OnGameStartEvent);
		}
	}

}