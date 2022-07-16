namespace Framework.Architecture
{
    public interface ISystem: IBelongToArchitecture,ICanSetArchitecture
    {
        void Init();
    }
    
    public abstract class AbstractSystem : ISystem
    {
        private IArchitecture _architecture;
        
        public IArchitecture GetArchitecture()
        {
            return _architecture;
        }

        public void SetArchitecture(IArchitecture architecture)
        {
            _architecture = architecture;
        }

        public abstract void Init();
    }
}