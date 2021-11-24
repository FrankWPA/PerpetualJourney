using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace PerpetualJourney
{
    public class LevelPart : MonoBehaviour, ICanBePooled
    {
        [SerializeField] private Transform _obstaclePosition;
        [SerializeField] private Transform _endPosition;
        [SerializeField] private List<Obstacle> _obstacles;
        [SerializeField] private List<Decoration> _decorations;
        [SerializeField] private Collectable _collectable;
        [SerializeField] private int CollectableQuantity = 5;
        [SerializeField] private float LevelSize = 30;
        [SerializeField] private float ObstacleChance = 0.7f;
        [SerializeField] private float DoubleObstacleChance = 0.2f/0.7f;

        public Vector3 LevelEndPosition => _endPosition.position;

        public event System.Action OnLevelDisable;

        private List<int> _availableLanes;

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
            this.RetrieveToObjectPool();
        }

        private void CreateObstacle()
        {
            Obstacle obstacle = InstantiateFromList(_obstacles, _obstaclePosition);

            int randomLane = Random.Range(0, _availableLanes.Count);
            int obstacleLane = _availableLanes[randomLane];
            _availableLanes.RemoveAt(randomLane);

            obstacle.Initialize(obstacleLane);
        }

        private void CreateDecoration()
        {
            InstantiateFromList(_decorations, transform);
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
            Collectable collectable = InstantiateAndSetParent(_collectable, transform);
            collectable.Initialize(_availableLanes[lane], OnLevelDisable);

            return collectable;
        }

        private T InstantiateFromList<T>(List<T> objectList, Transform parentToSet) where T : MonoBehaviour, ICanBePooled
        {
            int rndIndex = Random.Range(0, objectList.Count);
            
            return InstantiateAndSetParent(objectList[rndIndex], parentToSet);
        }

        private T InstantiateAndSetParent<T>(T obj, Transform parentToSet) where T : MonoBehaviour, ICanBePooled
        {
            T newObject = obj.RequestFromObjectPool();
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
