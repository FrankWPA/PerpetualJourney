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
        public event Action<int> OnScoreChanged;

        public void RequestPlayerPosition(ref Vector3 result)
        {
           Vector3? requestedPosition =  OnPlayerPositionRequest?.Invoke();
           if(requestedPosition != null)
           {
               result = requestedPosition.Value;
           }
        }

        public void ObstacleCollision()
        {
            OnObstacleCollided?.Invoke();
        }

        public void CollectableCollision()
        {
            OnCollectableCollided?.Invoke();
        }

        public void IncreasePlayerScore(int score)
        {
            OnScoreChanged?.Invoke(score);
        }
    }
}
