using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField]private GameManager gameManager;
        [SerializeField]private float _laneSize;

        public float LaneSize => _laneSize;
        public static GameSystem current;

        private void Awake()
        {
            current = this;
            gameManager.Initialize();
        }
    }
}
