using Example.Scripts.Model;
using Example.Scripts.System;
using Example.Scripts.Utils;
using Framework.Architecture;

namespace Example.Scripts {
	public class PointGame : Architecture<PointGame>
	{
		protected override void Init()
		{
			RegisterModel<IGameModel>(new GameModel());
			RegisterSystem<IGameSystem>(new GameSystem());
			RegisterUtils<IStorage>(new StorageLog());
		}
	}
}
