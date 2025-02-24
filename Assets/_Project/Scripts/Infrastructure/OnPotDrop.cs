using _Project.Scripts.VegetableEntity;
using R3;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    [RequireComponent(typeof(BoxCollider))]
    public class OnPotDrop : MonoBehaviour
    {
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private OnBadVegetableDrop _badVegetableDrop;
        public Subject<Vegetable> OnPotDropped = new();

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Vegetable>())
            {
                if (other.GetComponent<Vegetable>().IsGood)
                    _audioManager.PlayCorrect();

                if (!other.GetComponentInParent<Vegetable>().IsGood)
                {
                    _audioManager.PlayIncorrect();
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