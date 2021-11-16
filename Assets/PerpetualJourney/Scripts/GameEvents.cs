using System;
using UnityEngine;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "GameEvents", menuName = "Game Events")]
    public class GameEvents : ScriptableObject
    {
        public event Func<Vector3> OnPlayerPositionRequest;
        public event Action OnObstacleCollided;

        public Vector3? RequestPlayerPosition()
        {
           return OnPlayerPositionRequest?.Invoke();
        }

        public void ObstacleCollision()
        {
            OnObstacleCollided?.Invoke();
        }
    }
}
