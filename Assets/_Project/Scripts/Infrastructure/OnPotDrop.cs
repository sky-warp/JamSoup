using R3;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    [RequireComponent(typeof(BoxCollider))]
    public class OnPotDrop : MonoBehaviour
    { 
        public Subject<Draggable> OnPotDropped = new();
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Draggable>())
            {
                OnPotDropped.OnNext(other.gameObject.GetComponent<Draggable>());
                Destroy(other.gameObject);
            }
        }
    }
}