using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace _Project.Scripts.Audio
{
    public class VolumeSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private Slider _volumeSlider;

        private void Awake()
        {
            _volumeSlider.onValueChanged.AddListener(SetVolume);
        }

        private void SetVolume(float volume)
        {
            _audioMixer.SetFloat("MasterVolume", volume);
        }
    }
}