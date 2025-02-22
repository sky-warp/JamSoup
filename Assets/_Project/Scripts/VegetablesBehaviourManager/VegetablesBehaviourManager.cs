using _Project.Scripts.Infrastructure;
using _Project.Scripts.VegetableEntity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.VegetablesBehaviourManager
{
    public class VegetablesBehaviourManager : MonoBehaviour
    {
        [field:SerializeField] public VegSpawnerManager VegetableSpawner {get; private set;}
        
        private Vector3 _direction;
        
        private void Awake()
        {
            VegetableSpawner.OnSpawnedVegetable += GetCurrentVegetables;
        }

        private void OnDestroy()
        {
            VegetableSpawner.OnSpawnedVegetable -= GetCurrentVegetables;
        }

        public void GetCurrentVegetables(Vegetable vegetable, Vector3 targetPosition)
        {
            vegetable.transform.rotation = GetRandomDirection();
            
            vegetable.GetComponent<Force.Force>().FindTargetPosition(targetPosition);
            vegetable.ReadyForMove();
        }
        
        private Quaternion GetRandomDirection()
        {
            var tempRotation = Quaternion.identity;
            var tempVector = Vector3.zero;
            tempVector = tempRotation.eulerAngles;
            tempVector.y =Random.Range (0, 359);
            tempRotation.eulerAngles = tempVector;
            return tempRotation;
        }
    }
}
