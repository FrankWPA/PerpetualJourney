using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PerpetualJourney
{
    public class MenuSystem : MonoBehaviour
    {
        [SerializeField]private Button _playButton;
        [SerializeField]private Button _exitButton;

        private void Awake()
        {
            _playButton.onClick.AddListener(PlayGame);
            _exitButton.onClick.AddListener(ExitGame);
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
