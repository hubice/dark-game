using Example.Scripts.Event;
using Example.Scripts.Utils;
using Framework;
using Framework.Command;

namespace Example.Scripts.Command
{
	public class GameStartCommand : ICommand
	{
		public void Execute()
		{
			PointGame.OnRegisterPath += architecture =>
			{
				// PointGame.Register<IStorage>(new Storage());
			};
			GameStartEvent.Trigger();
		}
	}
}