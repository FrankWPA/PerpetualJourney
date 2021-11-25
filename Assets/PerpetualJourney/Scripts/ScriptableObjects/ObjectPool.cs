using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "ObjectPool", menuName = "PerpetualJourney/Object Pool")]
    public class ObjectPool: ScriptableObject
    {
        private Dictionary<string, Queue<GameObject>> _objectPool = new Dictionary<string, Queue<GameObject>>();

        public GameObject GetObject(GameObject gameObject)
        {
            if(TryGetObjectQueue(gameObject, out Queue<GameObject> objectQueue))
            {
                if(objectQueue.Count != 0)
                {
                    GameObject dequeuedObject = objectQueue.Dequeue();
                    if(dequeuedObject != null) 
                    {
                        dequeuedObject.SetActive(true);
                        return dequeuedObject;
                    }
                }
            }
            return InstantiateNewObject(gameObject);
        }

        public void ReturnObject(GameObject gameObject)
        {
            if (TryGetObjectQueue(gameObject, out Queue<GameObject> objectQueue))
            {
                objectQueue.Enqueue(gameObject);
            }
            else
            {
                Queue<GameObject> newObjectQueue = new Queue<GameObject>();
                newObjectQueue.Enqueue(gameObject);
                _objectPool.Add(gameObject.name, newObjectQueue);
            }

            gameObject.SetActive(false);
        }

        private GameObject InstantiateNewObject(GameObject gameObject)
        {
            GameObject newObject = Instantiate(gameObject);
            newObject.name = gameObject.name;

            return newObject;
        }

        private bool TryGetObjectQueue(GameObject gameObject, out Queue<GameObject> outQueue)
        {
            return _objectPool.TryGetValue(gameObject.name, out outQueue);
        }
    }
}
