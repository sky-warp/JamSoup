using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.PauseMenu
{
    public class PauseMenuController : MonoBehaviour
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private Button _backToMenuButton;

        [SerializeField] private GameObject _pauseMenu;

        public bool IsPaused { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        private void Awake()
        {
            _resumeButton.onClick.AddListener(Resume);
            _quitButton.onClick.AddListener(QuitGame);
            _backToMenuButton.onClick.AddListener(LoadMainMenu);
        }

        private void OnDestroy()
        {
            _resumeButton.onClick.RemoveAllListeners();
            _quitButton.onClick.RemoveAllListeners();
            _backToMenuButton.onClick.RemoveAllListeners();
        }

        private void Resume()
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }

        private void Pause()
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }

        private void LoadMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }

        private void QuitGame()
        {
            Application.Quit();
        }
    }
}