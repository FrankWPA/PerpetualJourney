using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PerpetualJourney
{
    public class MenuSystem : MonoBehaviour
    {
        [SerializeField]private InputReader _inputReader;
        [SerializeField]private Button _playButton;
        [SerializeField]private Button _exitButton;

        private void Awake()
        {
            _playButton.onClick.AddListener(PlayGame);
            _exitButton.onClick.AddListener(ExitGame);
            _inputReader.OnTapEvent += PlayGame;
            _inputReader.OnCloseEvent += ExitGame;
        }

        private void OnDisable()
        {
            _inputReader.OnTapEvent -= PlayGame;
            _inputReader.OnCloseEvent -= ExitGame;
        }

        private void PlayGame()
        {
            SceneManager.LoadScene("MainScene");
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
