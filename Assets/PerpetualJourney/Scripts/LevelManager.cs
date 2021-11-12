using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform levelGenPosition;
        [SerializeField] private List<Transform> levelList;
        [SerializeField] private Transform player;

        private Vector3 lastPosition;
        private Quaternion lastDirection;
        private const float GENERATION_DISTANCE = 200;

        private void Awake()
        {
            lastPosition = levelGenPosition.position;
            InstantiateLevelPart();
        }

        private void Update()
        {
            if (Vector3.Distance(player.position, lastPosition) < GENERATION_DISTANCE)
            {
                InstantiateLevelPart();
            }   
        }

        private void InstantiateLevelPart()
        {
            Transform randomLevel = levelList[Random.Range(0, levelList.Count)];
            Transform lastPartTransform = instatiateLevelPart(randomLevel, lastPosition);
            Transform endPosition = lastPartTransform.Find("EndPosition");
            lastPosition = endPosition.position;
            lastDirection = endPosition.rotation;
        }

        private Transform instatiateLevelPart(Transform levelPart, Vector3 instancePosition)
        {
            Transform levelTransform = Instantiate(levelPart, instancePosition, Quaternion.identity);
            levelTransform.rotation = lastDirection;
            return levelTransform;
        }
    }
}
