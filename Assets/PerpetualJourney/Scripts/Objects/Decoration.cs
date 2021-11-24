using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [RequireComponent(typeof(PoolableObject))]
    public class Decoration : MonoBehaviour, ICanBePooled
    {
        public PoolableObject GetPoolableObject()
        {
            return GetComponent<PoolableObject>();
        }
    }
}
