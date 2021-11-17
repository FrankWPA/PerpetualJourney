using System;
using UnityEngine;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "GameEvents", menuName = "PerpetualJourney/Game Events")]
    public class GameEvents : ScriptableObject
    {
        public event Func<Vector3> OnPlayerPositionRequest;
        public event Action OnObstacleCollided;
        public event Action OnCollectableCollided;
        public event Action<float> OnScoreChanged;

        public Vector3? RequestPlayerPosition()
        {
           return OnPlayerPositionRequest?.Invoke();
        }

        public void ObstacleCollision()
        {
            OnObstacleCollided?.Invoke();
        }

        public void CollectableCollision()
        {
            OnCollectableCollided?.Invoke();
        }

        public void IncreasePlayerScore(float score)
        {
            OnScoreChanged?.Invoke(score);
        }
    }
}
