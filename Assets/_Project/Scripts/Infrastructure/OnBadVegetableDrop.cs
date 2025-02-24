using _Project.Scripts.Audio;
using _Project.Scripts.VegetableEntity;
using UnityEngine;
using R3;

namespace _Project.Scripts.Infrastructure
{
    [RequireComponent(typeof(Collider))]
    public class OnBadVegetableDrop : MonoBehaviour
    {
        [SerializeField] private GameplayAudioManager gameplayAudioManager;
        public Subject<float> OnBadVegetableDroped = new();

        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.GetComponent<Vegetable>().IsGood)
            {
                gameplayAudioManager.PlayIncorrect();
                
                OnBadVegetableDroped?.OnNext(other.gameObject.GetComponent<Vegetable>().Score);
                Destroy(other.gameObject);
            }
        }
    }
}