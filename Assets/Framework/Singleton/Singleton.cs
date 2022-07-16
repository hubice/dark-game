using System;
using System.Reflection;

namespace Framework.Singleton
{
    public class Singleton<T> where T: Singleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get {
                if (_instance != null) return _instance;
                var ctorList = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                var ctor = Array.Find(ctorList, c => c.GetParameters().Length == 0);
                if (ctor == null)
                {
                    throw new Exception("Non-Public Constructor() not found in " + typeof(T));
                }
                _instance = ctor.Invoke(null) as T;
                return _instance;
            }
        }
    }
}
