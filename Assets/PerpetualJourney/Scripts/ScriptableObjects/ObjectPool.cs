using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "ObjectPool", menuName = "PerpetualJourney/Object Pool")]
    public class ObjectPool : ScriptableObject
    {
        private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();

        public GameObject GetGameObject(GameObject gameObject)
        {
            if(objectPool.TryGetValue(gameObject.name, out Queue<GameObject> objectList))
            {
                if(objectList.Count == 0)
                {
                    return InstantiateNewObject(gameObject);
                }
                else
                {
                    GameObject dequeuedObject = objectList.Dequeue();
                    dequeuedObject.SetActive(true);
                    return dequeuedObject;
                }
            }
            else
            {
                return InstantiateNewObject(gameObject);
            }
        }

        public GameObject InstantiateNewObject(GameObject gameObject)
        {
            GameObject newGameObject = Instantiate(gameObject);
            newGameObject.name = gameObject.name;
            return newGameObject;
        }
    }
}
