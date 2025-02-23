using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Project.Scripts.BackToMainMenuController
{
    public class BackToMainMenu : MonoBehaviour
    {
        [SerializeField] Button _backToMainMenuButton;

        private void Awake()
        {
            _backToMainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        }
    }
}