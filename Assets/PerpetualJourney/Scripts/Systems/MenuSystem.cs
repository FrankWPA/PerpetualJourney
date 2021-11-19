using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace PerpetualJourney
{
    public class MenuSystem : MonoBehaviour
    {
        [SerializeField]private Button _playButton;
        [SerializeField]private Button _exitButton;
        [SerializeField]private Slider _loadingProgress;
        [SerializeField]private GameObject _menuUi;
        [SerializeField]private GameObject _loadingScreen;

        private TextMeshProUGUI _loadingText;

        private void Awake()
        {
            _loadingText = _loadingProgress.GetComponentInChildren<TextMeshProUGUI>();
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
            _loadingText.SetText("Loading...{0}%", (int)(progress * 100f));
        }
    }
}
