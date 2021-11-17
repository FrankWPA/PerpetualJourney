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
        [SerializeField] private Colectable _colectable;
        [SerializeField] private float _obstacleChance = 0.7f;

        private List<int> _lanes = new List<int>{-1, 0 , 1};

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
            
            CreateCollectable();
        }

        private void CreateObstacle()
        {
            int rndIndex = Random.Range(0, _obstacles.Count);
            Obstacle randomObstacle = Instantiate(_obstacles[rndIndex], _obstaclePosition);

            rndIndex = Random.Range(0, _lanes.Count);
            int obstacleLane = _lanes[rndIndex];
            _lanes.RemoveAt(rndIndex);

            randomObstacle.Initialize(obstacleLane);
        }

        private void CreateDecoration()
        {
            int rndIndex = Random.Range(0, _decorations.Count);
            Instantiate(_decorations[rndIndex], transform);
        }

        private void CreateCollectable()
        {
            int rndIndex = Random.Range(0, _lanes.Count);
            Colectable colectable = Instantiate(_colectable, _obstaclePosition);
            colectable.Initialize(_lanes[rndIndex]);
        }
    }
}
