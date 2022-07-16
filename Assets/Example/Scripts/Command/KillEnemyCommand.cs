using Example.Scripts.System;
using Framework.Command;

namespace Example.Scripts.Command
{
	public struct KillEnemyCommand : ICommand
	{
		public void Execute()
		{
			PointGame.Get<IGameSystem>().Kill();
		}
	}
}
