using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "ObjectPool", menuName = "PerpetualJourney/Object Pool")]
    public class ObjectPool: ScriptableObject
    {
        private Dictionary<string, Queue<GameObject>> _objectPool = new Dictionary<string, Queue<GameObject>>();

        public T GetObject<T>(T monoObject) where T : MonoBehaviour
        {
            if(TryGetObjectQueue(monoObject, out Queue<GameObject> objectQueue))
            {
                if(objectQueue.Count != 0)
                {
                    GameObject dequeuedObject = objectQueue.Dequeue();
                    if(dequeuedObject != null) 
                    {
                        dequeuedObject.gameObject.SetActive(true);
                        return dequeuedObject.GetComponent<T>();
                    }
                }
            }
            return InstantiateNewObject(monoObject);
        }

        public void ReturnObject<T>(T poolableObject) where T : MonoBehaviour
        {
            GameObject gameObject = poolableObject.gameObject;

            if (TryGetObjectQueue(poolableObject, out Queue<GameObject> objectQueue))
            {
                objectQueue.Enqueue(gameObject);
            }
            else
            {
                Queue<GameObject> newObjectQueue = new Queue<GameObject>();
                newObjectQueue.Enqueue(gameObject);
                _objectPool.Add(poolableObject.name, newObjectQueue);
            }

            gameObject.SetActive(false);
        }

        private T InstantiateNewObject<T>(T poolableObject) where T : MonoBehaviour
        {
            T newObject = Instantiate(poolableObject);
            newObject.name = poolableObject.name;

            return newObject;
        }

        private bool TryGetObjectQueue<T>(T poolableObject, out Queue<GameObject> outQueue) where T : MonoBehaviour
        {
            return (_objectPool.TryGetValue(poolableObject.name, out outQueue));
        }
    }

    public static class PoolHelper
    {
        public static void RetrieveToPool<T>(this T monoPoolObject) where T : MonoBehaviour, ICanBePooled
        {
            PoolableObject poolableComponent =  monoPoolObject.GetPoolableObject();

            if (poolableComponent != null)
            {
                ObjectPool pool = poolableComponent.Pool;
                pool.ReturnObject(monoPoolObject);
            }
        }

        public static T RequestFromPool<T>(this T monoPoolObject) where T : MonoBehaviour, ICanBePooled
        {
            PoolableObject poolableComponent = monoPoolObject.GetPoolableObject();
            
            if (poolableComponent != null)
            {
                ObjectPool pool = poolableComponent.Pool;
                return pool.GetObject(monoPoolObject);
            }

            return null;
        }
    }
}
