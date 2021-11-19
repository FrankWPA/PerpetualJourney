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
        [SerializeField]private GameObject _cameraObject;

        public static GameSystem instance;
        public float LaneSize => _laneSize;
        
        private void Awake()
        {
            PersistentLoaderSystem.instance.GameIsLoaded += ActivateCamera;
            instance = this;
            
            _gameManager.Initialize();
            _levelManager.Initialize();
        }

        private void OnDisable()
        {
            PersistentLoaderSystem.instance.GameIsLoaded -= ActivateCamera;
        }

        private void ActivateCamera()
        {
            _cameraObject.SetActive(true);
        }
    }
}
