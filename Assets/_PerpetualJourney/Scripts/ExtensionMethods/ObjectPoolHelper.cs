using UnityEngine;

namespace PerpetualJourney
{
    public static class ObjectPoolHelper
    {
        public static void RetrieveToObjectPool<T>(this T poolObject) where T : MonoBehaviour, ICanBePooled
        {
            ObjectPool pool =  GameSystem.Instance.ObjectPooling;
            pool.ReturnObject(poolObject.gameObject);
        }

        public static T RequestFromObjectPool<T>(this T poolObject) where T : MonoBehaviour, ICanBePooled
        {
            ObjectPool pool =  GameSystem.Instance.ObjectPooling;
            GameObject gameObject = pool.GetObject(poolObject.gameObject);
            
            return gameObject.GetComponent<T>();
        }
    }
}
