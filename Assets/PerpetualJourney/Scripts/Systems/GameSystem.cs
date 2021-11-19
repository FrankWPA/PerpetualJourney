using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PerpetualJourney
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField]private GameManager _gameManager;
        [SerializeField]private LevelManager _levelManager;
        [SerializeField]private float _laneSize;

        public static GameSystem Current {get; private set;}
        public float LaneSize => _laneSize;
        
        private void Start()
        {         
            if (Current == null)
            {
                Current = this;
            }
            
            _gameManager.Initialize();
            _levelManager.Initialize();
        }
    }
}
