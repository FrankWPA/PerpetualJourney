using UnityEngine;

namespace PerpetualJourney
{
    public class PoolableObject : MonoBehaviour
    {
        [SerializeField]private ObjectPool _pool;

        public ObjectPool Pool => _pool;
    }
}
