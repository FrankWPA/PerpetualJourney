using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PerpetualJourney
{
    public class GameSystem : MonoBehaviour
    {
        [SerializeField]private GameManager _gameManager;
        [SerializeField]private LevelManager _levelManager;
        [SerializeField]private List<GameObject> _activateOnLoadObjects;
        [SerializeField]private float _laneSize;
        [SerializeField]private Button _replayButton;
        [SerializeField]private Button _exitButton;

        public ObjectPool ObjectPooling {get; private set;}
        public static GameSystem Instance;
        public float LaneSize => _laneSize;
        
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
            PersistentLoaderSystem.Instance.GameIsLoaded += ActivateGameObjects;
            Instance = this;

            _gameManager.Initialize();
            _levelManager.Initialize();
            _replayButton.onClick.AddListener(ResetScene);
            _exitButton.onClick.AddListener(ReturnToMenu);
        }

        private void RemoveEventSubscriptions()
        {
            PersistentLoaderSystem.Instance.GameIsLoaded -= ActivateGameObjects;
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
            LevelPart[] levels = _levelManager.GetComponentsInChildren<LevelPart>();
            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].SceneReset();
            }

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
