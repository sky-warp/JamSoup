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
        [SerializeField] private Button _backToMainMenuFromOptionsButton;
        [SerializeField] private Button _tutorialButton;
        [SerializeField] private Button _backToMainMenuFromTutorialButton;

        [SerializeField] private GameObject _optionsMenu;
        [SerializeField] private GameObject _tutorialMenu;

        private void Awake()
        {
            _startGameButton.onClick.AddListener(PlayGame);
            _quitGameButton.onClick.AddListener(QuitGame);
            _optionsButton.onClick.AddListener(ShowOptionsMenu);
            _backToMainMenuFromOptionsButton.onClick.AddListener(BackToMainMenuFromOptions);
            _tutorialButton.onClick.AddListener(ShowTutorial);
            _backToMainMenuFromTutorialButton.onClick.AddListener(BackToMainMenuFromTutorial);
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveAllListeners();
            _quitGameButton.onClick.RemoveAllListeners();
            _optionsButton.onClick.RemoveAllListeners();
            _backToMainMenuFromOptionsButton.onClick.RemoveAllListeners();
            _tutorialButton.onClick.RemoveAllListeners();
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

        private void BackToMainMenuFromOptions()
        {
            _optionsMenu.SetActive(false);
            gameObject.SetActive(true);
        }

        private void ShowTutorial()
        {
            _tutorialMenu.SetActive(true);
            gameObject.SetActive(false);
        }

        private void BackToMainMenuFromTutorial()
        {
            _tutorialMenu.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}