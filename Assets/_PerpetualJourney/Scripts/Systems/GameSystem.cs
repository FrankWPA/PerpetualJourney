using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PerpetualJourney
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private LevelManager _levelManager;
        [SerializeField] private List<GameObject> _activateOnLoadObjects;
        [SerializeField] private Button _replayButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private float _laneSize;

        public ObjectPool ObjectPooling {get; private set;}
        public float LaneSize => _laneSize;
        
        public static GameSystem Instance;
        
        private void Awake()
        {
            InitializeSystem();
        }

        private void OnDisable()
        {
            RemoveEventSubscriptions();
        }

        private void InitializeSystem()
        {
            ObjectPooling = ScriptableObject.CreateInstance<ObjectPool>();
            Instance = this;

            PersistentLoaderSystem.Instance.OnGameIsLoaded += ActivateGameObjects;
            _replayButton.onClick.AddListener(ResetScene);
            _exitButton.onClick.AddListener(ReturnToMenu);

            _gameManager.Initialize();
            _levelManager.Initialize();
        }

        private void RemoveEventSubscriptions()
        {
            PersistentLoaderSystem.Instance.OnGameIsLoaded -= ActivateGameObjects;
        }

        private void ActivateGameObjects()
        {
            for(int i = 0; i < _activateOnLoadObjects.Count; i++)
            {
                _activateOnLoadObjects[i].SetActive(true);
            }
        }
        
        private void ResetScene()
        {
            PlayClickSound();

            _gameManager.SceneReset();
            _levelManager.SceneReset();
        }

        private void ReturnToMenu()
        {
            PlayClickSound();
            PersistentLoaderSystem.Instance.LoadMenu();
        }

        private void PlayClickSound()
        {
            SoundPlayer.Instance.PlayAudio(SoundPlayer.AudioEnum.Click);
        }
    }
}
