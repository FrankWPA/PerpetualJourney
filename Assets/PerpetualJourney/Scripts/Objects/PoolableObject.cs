using UnityEngine;

namespace PerpetualJourney
{
    public abstract class PoolableObject : MonoBehaviour
    {
        [SerializeField]protected ObjectPool _pool;

        public void Disable()
        {
            _pool.ReturnObject(this);
        }
    }
}
