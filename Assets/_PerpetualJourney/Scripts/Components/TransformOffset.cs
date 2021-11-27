using System;
using UnityEngine;

namespace PerpetualJourney{
    public class TransformOffset : MonoBehaviour
    {
        [SerializeField] private Vector3 _positionOffset;
        [SerializeField] private LockPosition _lockPos;

        [Serializable]
        private struct LockPosition
        {
            public bool LockPosX;
            public bool LockPosY;
            public bool LockPosZ;

            public Vector3 ToScale()
            {
                Vector3 lockScale = new Vector3()
                {
                    x = Convert.ToInt32(!LockPosX),
                    y = Convert.ToInt32(!LockPosY),
                    z = Convert.ToInt32(!LockPosZ)
                };
                return lockScale;
            }
        }

        private Transform _target;
        private Vector3 _lockScale;

        public void Initialize(Transform targetToOffset)
        {
            _target = targetToOffset;
            UpdateLockScale();
        }

        private void UpdateLockScale()
        {
            _lockScale = _lockPos.ToScale();
        }

        private void FixedUpdate() {
            if(_target != null)
            {
                MoveToOffsetPosition();
            }
        }

        private void MoveToOffsetPosition()
        {
            transform.position = Vector3.Scale(_target.position, _lockScale) + _positionOffset;
        }
    }
}
