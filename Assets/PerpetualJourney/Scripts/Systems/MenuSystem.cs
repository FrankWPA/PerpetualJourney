using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PerpetualJourney
{
    public class MenuSystem : MonoBehaviour
    {
        [SerializeField]private Button _playButton;
        [SerializeField]private Button _exitButton;
        [SerializeField]private Slider _loadingProgress;
        [SerializeField]private GameObject _menuUi;
        [SerializeField]private GameObject _loadingScreen;

        private void Awake()
        {
            _playButton.onClick.AddListener(PlayGame);
            _exitButton.onClick.AddListener(ExitGame);
            PersistentLoaderSystem.instance.OnProgressUpdated += OnLoading;
        }

        private void OnDisable()
        {
            PersistentLoaderSystem.instance.OnProgressUpdated -= OnLoading;
        }

        private void PlayGame()
        {
            _menuUi.SetActive(false);
            _loadingScreen.SetActive(true);
            PersistentLoaderSystem.instance.LoadGame();
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void OnLoading(float progress)
        {
            _loadingProgress.value = progress;
        }
    }
}
