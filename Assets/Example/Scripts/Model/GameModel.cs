using Example.Scripts.System;
using Example.Scripts.Utils;
using Framework.Architecture;
using Framework.BindableProperty;
using NotImplementedException = System.NotImplementedException;

namespace Example.Scripts.Model
{
	public interface IGameModel: IModel
	{
		public BindableProperty<int> KillCount { get; }
	}

	public class GameModel : AbstractModel, IGameModel
	{
		public override void Init()
		{
			var storage = GetArchitecture().GetUtils<IStorage>();
			
			KillCount.Value = storage.LoadInt("GameModel_killCount", 0);
			KillCount.OnValueChanged += (count) =>
			{
				storage.SaveInt("GameModel_killCount", count);
			};
		}

		public BindableProperty<int> KillCount { get; } = new BindableProperty<int>()
		{
			Value = 0
		};
	}
}