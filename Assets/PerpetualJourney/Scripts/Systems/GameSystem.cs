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
        [SerializeField]private float _laneSize;
        [SerializeField]private GameObject _gameUI;
        [SerializeField]private Button _replayButton;
        [SerializeField]private Button _exitButton;

        public static GameSystem instance;
        public float LaneSize => _laneSize;
        
        private void Awake()
        {
            PersistentLoaderSystem.instance.GameIsLoaded += ActivateUi;
            instance = this;
            
            _gameManager.Initialize();
            _levelManager.Initialize();
            _replayButton.onClick.AddListener(ResetScene);
            _exitButton.onClick.AddListener(ReturnToMenu);
        }

        private void OnDisable()
        {
            PersistentLoaderSystem.instance.GameIsLoaded -= ActivateUi;
        }

        private void ActivateUi()
        {
            _gameUI.SetActive(true);
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
            PersistentLoaderSystem.instance.LoadMenu();
        }

        private void PlayClickSound()
        {
            SoundPlayer.instance.PlayAudio(SoundPlayer.AudioEnum.Click);
        }
    }
}
