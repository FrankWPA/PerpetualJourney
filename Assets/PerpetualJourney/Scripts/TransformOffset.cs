using System;
using UnityEngine;

namespace PerpetualJourney{
    public class TransformOffset : MonoBehaviour
    {
        [SerializeField]private Vector3 _positionOffset;
        [SerializeField]private LockPosition _lockPos;

        [Serializable]
        private struct LockPosition
        {
            public bool lockPosX;
            public bool lockPosY;
            public bool lockPosZ;

            public Vector3 ToScale()
            {
                Vector3 lockScale = new Vector3();
                lockScale.x = Convert.ToInt32(!lockPosX);
                lockScale.y = Convert.ToInt32(!lockPosY);
                lockScale.z = Convert.ToInt32(!lockPosZ);
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
            transform.position = Vector3.Scale(_target.position, _lockScale) + _positionOffset;
        }
    }
}
