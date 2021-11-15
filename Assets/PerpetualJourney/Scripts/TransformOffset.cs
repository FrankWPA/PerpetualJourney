using System;
using UnityEngine;

namespace PerpetualJourney{
    public class TransformOffset : MonoBehaviour
    {
        [SerializeField]private Vector3 positionOffset;
        [SerializeField]private LockPosition lockPos;

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

        private Transform target;
        private Vector3 lockScale;

        public void Initialize(Transform targetToOffset)
        {
            target = targetToOffset;
            UpdateLockScale();
        }

        private void UpdateLockScale()
        {
            lockScale = lockPos.ToScale();
        }

        private void FixedUpdate() {
            transform.position = Vector3.Scale(target.position, lockScale) + positionOffset;
        }
    }
}
