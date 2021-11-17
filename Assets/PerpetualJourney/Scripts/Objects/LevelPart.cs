using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class LevelPart : PoolableObject
    {
        [SerializeField] private Transform _obstaclePosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private List<Obstacle> _obstacles;
        [SerializeField] private List<Decoration> _decorations;
        [SerializeField] private Collectable _collectable;

        public Vector3 LevelEndPosition => _endPosition.position;

        private const float ObstacleChance = 0.7f;
        private const float DoubleObstacleChance = 0.2f/ObstacleChance;
        private List<int> _availableLanes;

        public event System.Action OnLevelDisable;

        public void Initialize()
        {
            _availableLanes = new List<int>{-1, 0 , 1};
            
            float rndValue = Random.Range(0, 1f);

            if (ObstacleChance >= rndValue)
            {
                if(DoubleObstacleChance >= rndValue)
                {
                    CreateObstacle();
                }

                CreateObstacle();
            }
            else
            {
                CreateDecoration();
            }
            
            CreateCollectable();
        }

        private void CreateObstacle()
        {
            int rndIndex = Random.Range(0, _obstacles.Count);
            Obstacle obstacle = _pool.GetObject(_obstacles[rndIndex]);
            obstacle.transform.SetParent(_obstaclePosition, false);
            OnLevelDisable += obstacle.Disable;

            int randomLane = Random.Range(0, _availableLanes.Count);
            int obstacleLane = _availableLanes[randomLane];
            _availableLanes.RemoveAt(randomLane);

            obstacle.Initialize(obstacleLane);
        }

        private void CreateDecoration()
        {
            int rndIndex = Random.Range(0, _decorations.Count);
            Decoration decoration = _pool.GetObject(_decorations[rndIndex]);
            decoration.transform.SetParent(transform, false);
            OnLevelDisable += decoration.Disable;
        }

        private void CreateCollectable()
        {
            Collectable collectable = _pool.GetObject(_collectable);
            collectable.transform.SetParent(_obstaclePosition, false);

            int randomLane = Random.Range(0, _availableLanes.Count);
            collectable.Initialize(_availableLanes[randomLane], this);
        }

        private void OnTriggerExit(Collider other)
        {
            OnLevelDisable?.Invoke();
            OnLevelDisable = null;
            Disable();
        }
    }
}
