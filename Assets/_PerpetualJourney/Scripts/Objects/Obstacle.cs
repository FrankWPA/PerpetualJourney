using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class Obstacle : LaneObject
    {
        protected override void CollidedWithPlayer()
        {
            _gameEvents.ObstacleCollision();
        }
    }
}
