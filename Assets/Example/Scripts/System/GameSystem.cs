using Example.Scripts.Event;
using Example.Scripts.Model;
using Framework.Architecture;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Example.Scripts.System
{
    public interface IGameSystem: ISystem
    {
        void Kill();
    }

    public class GameSystem :  AbstractSystem, IGameSystem
    {
        public void Kill()
        {
            var gameModel = GetArchitecture().GetModel<IGameModel>();
            gameModel.KillCount.Value++;
            if (gameModel.KillCount.Value >= 3)
            {
            	GameEndEvent.Trigger();
            }
        }

        public override void Init()
        {
        }
    }
}