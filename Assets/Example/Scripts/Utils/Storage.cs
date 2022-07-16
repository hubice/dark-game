using Framework.Architecture;
using UnityEngine;

namespace Example.Scripts.Utils
{
    public interface IStorage: IUtils
    {
        void SaveInt(string key, int value);
        int LoadInt(string key, int defaultValue = 0);
    }

    public class StorageLog : IStorage
    {
        public void SaveInt(string key, int value)
        {
            Debug.Log($"StorageLog SaveInt key:{key} value:{value}");
        }
        
        public int LoadInt(string key, int defaultValue = 0)
        {
            Debug.Log($"StorageLog LoadInt key:{key}");
            return 0;
        }
    }
    
    
    public class Storage : IStorage
    {
        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }
        
        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }
    }
}