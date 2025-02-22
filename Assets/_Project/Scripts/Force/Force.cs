using _Project.Scripts.VegetableEntity;
using UnityEngine;

namespace _Project.Scripts.Force
{
    public class Force : MonoBehaviour
    {
        public Vector3 TargetPosition { get; private set; }
        
        private Rigidbody _rb;
        private float _forceSpeed;
        private Vegetable _vegetable;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _vegetable = gameObject.GetComponent<Vegetable>();
            _forceSpeed = _vegetable.Speed;
        }

        public void FindTargetPosition(Vector3 targetPosition)
        {
            TargetPosition = targetPosition;
        }
        
        private void FixedUpdate()
        {
            if (_vegetable.IsReadyForMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, TargetPosition, _forceSpeed * Time.fixedDeltaTime);
            }
        }
    }
}