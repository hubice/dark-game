using System;
using System.Collections.Generic;
using Framework.IOC;

namespace Framework.Architecture
{
    public interface IArchitecture
    {
        T GetUtils<T>() where T : class, IUtils;
        T GetModel<T>() where T : class, IModel;
        void RegisterModel<T1>(T1 model) where T1 : IModel;
        void RegisterSystem<T1>(T1 system) where T1 : ISystem;
        void RegisterUtils<T1>(T1 utils) where T1: IUtils;
    }
    
    public abstract class Architecture<T>: IArchitecture where T : Architecture<T>, new()
    {
        private static T _architecture;
        public static Action<T> OnRegisterPath = architecture => {};
        private static void MakeSureContainer()
        {
            if (_architecture != null) return;
            _architecture = new T();
            _architecture.Init();

            OnRegisterPath?.Invoke(_architecture);
            
            foreach (var model in _architecture._modelList)
            {
                model.Init();
            }
            _architecture._modelList.Clear();
            foreach (var system in _architecture._systemList)
            {
                system.Init();
            }
            _architecture._systemList.Clear();
            
            _architecture._isInitEnd = true;
        }
        public static T1 Get<T1>() where T1 : class
        {
            MakeSureContainer();
            return _architecture._container.Get<T1>();
        }
        public static void Register<T1>(T1 instance)
        {
            MakeSureContainer();
            _architecture._container.Register<T1>(instance);
        }

        public static IArchitecture Interface
        {
            get
            {
                if (_architecture == null)
                {
                    MakeSureContainer();
                }

                return _architecture;

            }
        }


        private readonly IOCContainer _container = new IOCContainer();
        private bool _isInitEnd = false;
        private readonly List<IModel> _modelList = new List<IModel>();
        private readonly List<ISystem> _systemList = new List<ISystem>();
        
        protected abstract void Init();
        
        public void RegisterModel<T1>(T1 model) where T1 : IModel
        {
            model.SetArchitecture(this);
            _container.Register<T1>(model);
            if (!_isInitEnd)
            {
                _modelList.Add(model);
            }
            else
            {
                model.Init();
            }
        }

        public void RegisterSystem<T1>(T1 system) where T1 : ISystem
        {
            system.SetArchitecture(this);
            _container.Register<T1>(system);
            if (!_isInitEnd)
            {
                _systemList.Add(system);
            }
            else
            {
                system.Init();
            }
        }
        
        public void RegisterUtils<T1>(T1 utils) where  T1 : IUtils
        {
            _container.Register<T1>(utils);
        } 
        
        public T1 GetUtils<T1>() where T1 : class, IUtils
        {
            return _container.Get<T1>();
        }
        
        public T1 GetModel<T1>() where T1 : class, IModel
        {
            return _container.Get<T1>();
        }
    }
}