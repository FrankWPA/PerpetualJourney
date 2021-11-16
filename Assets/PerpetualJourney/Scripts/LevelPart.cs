using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class LevelPart : MonoBehaviour
    {
        [SerializeField] private Transform _obstaclePosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private List<Obstacle> _obstacles;
        [SerializeField] private List<Transform> _decorations;
        [SerializeField] private float _obstacleChance = 0.7f;

        public Vector3 LevelEndPosition => _endPosition.position;

        public void Initialize()
        {
            float value = Random.Range(0, 1f);
            if (value <=  _obstacleChance)
            {
                CreateObstacle();
            }
            else
            {
                CreateDecoration();
            }
        }

        private void CreateObstacle()
        {
            int rndIndex = Random.Range(0, _obstacles.Count);
            Obstacle randomObstacle = Instantiate(_obstacles[rndIndex], _obstaclePosition);
            randomObstacle.Initialize(Random.Range(-1, 2));
        }

        private void CreateDecoration()
        {
            int rndIndex = Random.Range(0, _decorations.Count);
            Instantiate(_decorations[rndIndex], transform);
        }
    }
}
