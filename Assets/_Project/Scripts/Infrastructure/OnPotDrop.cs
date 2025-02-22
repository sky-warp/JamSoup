using _Project.Scripts.VegetableEntity;
using R3;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    [RequireComponent(typeof(BoxCollider))]
    public class OnPotDrop : MonoBehaviour
    { 
        public Subject<Vegetable> OnPotDropped = new();
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Vegetable>())
            {
                OnPotDropped.OnNext(other.gameObject.GetComponent<Vegetable>());
                Destroy(other.gameObject);
            }
        }
    }
}