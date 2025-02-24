using UnityEngine;

namespace _Project.Scripts
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _correct;
        [SerializeField] private AudioSource _incorrect;

        public void PlayCorrect()
        {
            _correct.Play();
        }

        public void PlayIncorrect()
        {
            _incorrect.Play();
        }
    }
}