using System.Collections.Generic;
using System.Collections;
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

        private const int CollectableQuantity = 5;
        private const float LevelSize = 30;
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
            
            CreateCollectables(CollectableQuantity, LevelSize);
        }

        public void SceneReset()
        {
            OnLevelDisable?.Invoke();
            OnLevelDisable = null;
            Disable();
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

        private void CreateCollectables(int quantity, float levelSize)
        {
            int randomLane = Random.Range(0, _availableLanes.Count);
            float dist = levelSize/(quantity + 1);
            for(int i = 1; i <= quantity; i++)
            {
                Collectable collectable = CreateCollectable(randomLane);
                collectable.transform.LeanSetLocalPosX(-dist * i);
            }
        }

        private Collectable CreateCollectable(int lane)
        {
            Collectable collectable = _pool.GetObject(_collectable);
            collectable.transform.SetParent(transform, false);

            collectable.Initialize(_availableLanes[lane], this);
            return collectable;
        }

        private void OnTriggerExit(Collider other)
        {
            if(other.GetComponentInParent<Player>() != null)
            {
                StartCoroutine(DellayedLevelDisableAsync());
            }
        }

        private IEnumerator DellayedLevelDisableAsync()
        {
            yield return new WaitForSeconds(2);
            SceneReset();
        }
    }
}
