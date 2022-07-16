using Example.Scripts.Command;
using Example.Scripts.Model;
using Framework.Architecture;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Example.Scripts.Game
{
	public class Enemy : MonoBehaviour, IController
	{
		private void OnMouseDown()
		{
			Debug.Log(GetArchitecture().GetModel<IGameModel>().KillCount.Value);

			Destroy(gameObject);
			new KillEnemyCommand().Execute(); 
		}

		public IArchitecture GetArchitecture()
		{
			return PointGame.Interface;
		}
	}
}
