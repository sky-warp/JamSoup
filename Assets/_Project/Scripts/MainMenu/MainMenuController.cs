using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _quitGameButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _backToMainMenuButton;

        [SerializeField] private GameObject _optionsMenu;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(PlayGame);
            _quitGameButton.onClick.AddListener(QuitGame);
            _optionsButton.onClick.AddListener(ShowOptionsMenu);
            _backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveAllListeners();
            _quitGameButton.onClick.RemoveAllListeners();
            _optionsButton.onClick.RemoveAllListeners();
            _backToMainMenuButton.onClick.RemoveAllListeners();
        }

        private void PlayGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        private void ShowOptionsMenu()
        {
            _optionsMenu.SetActive(true);
            gameObject.SetActive(false);
        }

        private void BackToMainMenu()
        {
            _optionsMenu.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}