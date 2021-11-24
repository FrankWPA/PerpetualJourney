using UnityEngine;

namespace PerpetualJourney
{
    public static class ObjectPoolHelper
    {
        public static void RetrieveToObjectPool<T>(this T monoPoolObject) where T : MonoBehaviour, ICanBePooled
        {
            ObjectPool pool =  GameSystem.Instance.ObjectPooling;
            pool.ReturnObject(monoPoolObject.gameObject);
        }

        public static T RequestFromObjectPool<T>(this T monoPoolObject) where T : MonoBehaviour, ICanBePooled
        {
            ObjectPool pool =  GameSystem.Instance.ObjectPooling;
            GameObject gameObject = pool.GetObject(monoPoolObject.gameObject);
            
            return gameObject.GetComponent<T>();
        }
    }
}
