using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace PerpetualJourney
{
    public class LevelPart : MonoBehaviour, ICanBePooled
    {
        [SerializeField] private Transform _obstaclePosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private LevelPartValues _levelValues;

        public Vector3 LevelEndPosition => _endPosition.position;

        public event System.Action OnLevelDisable;

        private List<int> _availableLanes;

        public void Initialize()
        {
            _availableLanes = new List<int>{-1, 0 , 1};
            
            float rndValue = Random.Range(0, 1f);

            if (_levelValues.ObstacleChance >= rndValue)
            {
                if(_levelValues.DoubleObstacleChance >= rndValue)
                {
                    CreateObstacle();
                }

                CreateObstacle();
            }
            else
            {
                CreateDecoration();
            }
            
            CreateCollectables(_levelValues.CollectableQuantity, _levelValues.LevelSize);
        }

        public void SceneReset()
        {
            OnLevelDisable?.Invoke();
            OnLevelDisable = null;
            this.RetrieveToObjectPool();
        }

        private void CreateObstacle()
        {
            Obstacle obstacle = RequestFromPool(_levelValues.Obstacles, _obstaclePosition);

            int randomLane = Random.Range(0, _availableLanes.Count);
            int obstacleLane = _availableLanes[randomLane];
            _availableLanes.RemoveAt(randomLane);

            obstacle.Initialize(obstacleLane);
        }

        private void CreateDecoration()
        {
            RequestFromPool(_levelValues.Decorations, transform);
        }

        private void CreateCollectables(int quantity, float levelSize)
        {
            int randomLane = Random.Range(0, _availableLanes.Count);
            int lane = _availableLanes[randomLane];
            float dist = levelSize/(quantity + 1);

            for(int i = 1; i <= quantity; i++)
            {
                Collectable collectable = CreateCollectable(lane);
                collectable.transform.LeanSetLocalPosX(-dist * i);
            }
        }

        private Collectable CreateCollectable(int lane)
        {
            Collectable collectable = RequestFromPool(_levelValues.Collectable, transform);
            collectable.Initialize(lane, this);

            return collectable;
        }

        private T RequestFromPool<T>(List<T> objectList, Transform parentToSet) where T : MonoBehaviour, ICanBePooled
        {
            int rndIndex = Random.Range(0, objectList.Count);
            
            return RequestFromPool(objectList[rndIndex], parentToSet);
        }

        private T RequestFromPool<T>(T poolableObject, Transform parentToSet) where T : MonoBehaviour, ICanBePooled
        {
            T newObject = poolableObject.RequestFromObjectPool();
            newObject.transform.SetParent(parentToSet, false);

            OnLevelDisable += newObject.RetrieveToObjectPool;

            return newObject;
        }

        private void OnTriggerExit(Collider other)
        {
            CheckPlayerExit(other);
        }

        private void CheckPlayerExit(Collider other)
        {
            if (other.GetComponentInParent<Player>() != null)
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
