using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [RequireComponent(typeof(PoolableObject))]
    public abstract class LaneObject : MonoBehaviour, ICanBePooled
    {
        [SerializeField]private GameEvents _gameEvents;

        private float _laneSize;
        private int _lane;

        protected GameEvents GameEvent => _gameEvents;

        public virtual void Initialize(int lane)
        {
            _lane = lane;
            _laneSize = GameSystem.Instance.LaneSize;
            SetLanePosition();
        }

        public PoolableObject GetPoolableObject()
        {
            return GetComponent<PoolableObject>();
        }

        protected abstract void CollidedWithPlayer();

        private void SetLanePosition()
        {
            Vector3 lanePos = transform.position;
            lanePos.z = _lane * _laneSize;
            transform.position = lanePos;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<Player>() != null)
            {
                CollidedWithPlayer();
            }
        }
    }
}
