using _Project.Scripts.VegetableEntity;
using UnityEngine;
using R3;

namespace _Project.Scripts.Infrastructure
{
    [RequireComponent(typeof(Collider))]
    public class OnBadVegetableDrop : MonoBehaviour
    {
        public Subject<int> OnBadVegetableDroped = new();

        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Vegetable>().IsGood == false)
            {
                OnBadVegetableDroped?.OnNext(other.gameObject.GetComponent<Vegetable>().Score);
                Destroy(other.gameObject);
            }
        }
    }
}