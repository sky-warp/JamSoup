using _Project.Scripts.Audio;
using _Project.Scripts.VegetableEntity;
using R3;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    [RequireComponent(typeof(BoxCollider))]
    public class OnPotDrop : MonoBehaviour
    {
        [SerializeField] private GameplayAudioManager gameplayAudioManager;
        [SerializeField] private OnBadVegetableDrop _badVegetableDrop;
        public Subject<Vegetable> OnPotDropped = new();

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Vegetable>())
            {
                if (other.GetComponent<Vegetable>().IsGood)
                    gameplayAudioManager.PlayCorrect();

                if (!other.GetComponentInParent<Vegetable>().IsGood)
                {
                    gameplayAudioManager.PlayIncorrect();
                    _badVegetableDrop.OnBadVegetableDroped.OnNext(other.GetComponentInParent<Vegetable>().Score);
                    Destroy(other.gameObject);
                    return;
                }

                OnPotDropped.OnNext(other.gameObject.GetComponent<Vegetable>());
                Destroy(other.gameObject);
            }
        }
    }
}