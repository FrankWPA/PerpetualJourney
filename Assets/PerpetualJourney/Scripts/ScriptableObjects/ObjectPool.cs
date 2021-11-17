using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "ObjectPool", menuName = "PerpetualJourney/Object Pool")]
    public class ObjectPool: ScriptableObject
    {
        private Dictionary<string, Queue<PoolableObject>> _objectPool = new Dictionary<string, Queue<PoolableObject>>();

        public T GetObject<T>(T poolableObject) where T : PoolableObject
        {
            if(TryGetObjectQueue(poolableObject, out Queue<PoolableObject> objectQueue))
            {
                if(objectQueue.Count != 0)
                {
                    T dequeuedObject = (T)objectQueue.Dequeue();
                    dequeuedObject.gameObject.SetActive(true);
                    return dequeuedObject;
                }
            }
            
            return InstantiateNewObject(poolableObject);
        }

        public void ReturnObject<T>(T poolableObject) where T : PoolableObject
        {
            if (TryGetObjectQueue(poolableObject, out Queue<PoolableObject> objectQueue))
            {
                objectQueue.Enqueue(poolableObject);
            }
            else
            {
                Queue<PoolableObject> newObjectQueue = new Queue<PoolableObject>();
                newObjectQueue.Enqueue(poolableObject);
                _objectPool.Add(poolableObject.name, newObjectQueue);
            }

            poolableObject.gameObject.SetActive(false);
        }

        private T InstantiateNewObject<T>(T poolableObject) where T : PoolableObject
        {
            T newObject = Instantiate(poolableObject);
            newObject.name = poolableObject.name;
            return newObject;
        }

        private bool TryGetObjectQueue(PoolableObject poolableObject, out Queue<PoolableObject> outQueue)
        {
            return (_objectPool.TryGetValue(poolableObject.name, out outQueue));
        }
    }
}
