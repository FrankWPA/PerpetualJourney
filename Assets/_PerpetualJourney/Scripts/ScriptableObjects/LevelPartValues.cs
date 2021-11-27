using System;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    [CreateAssetMenu(fileName = "LevelPartValues", menuName = "PerpetualJourney/Level Values")]
    public class LevelPartValues : ScriptableObject
    {
        public List<Obstacle> Obstacles;
        public List<Decoration> Decorations;
        public Collectable Collectable;
        public int CollectableQuantity = 5;
        public float LevelSize = 30;
        public float ObstacleChance = 0.7f;
        public float DoubleObstacleChance = 0.2f/0.7f;
    }
}
