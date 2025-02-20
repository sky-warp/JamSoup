using TMPro;
using UnityEngine;

namespace _Project.Scripts.Timer
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private float _elapsedTime;

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            
            int minutes = Mathf.FloorToInt(_elapsedTime / 60);
            int seconds = Mathf.FloorToInt(_elapsedTime % 60);
            
            _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}