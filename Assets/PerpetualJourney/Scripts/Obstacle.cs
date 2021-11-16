using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class Obstacle : MonoBehaviour
    {
        private float _laneSize;
        private int _lane;

        public void Initialize(int lane)
        {
            _lane = lane;
            _laneSize = GameSystem.Current.LaneSize;
            SetLanePosition();
        }

        private void SetLanePosition()
        {
            Vector3 lanePos = transform.position;
            lanePos.z = _lane * _laneSize;
            transform.position = lanePos;
        }
    }
}
