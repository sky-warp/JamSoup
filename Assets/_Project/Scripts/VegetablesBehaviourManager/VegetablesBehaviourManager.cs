using _Project.Scripts.Infrastructure;
using UnityEngine;

namespace _Project.Scripts.VegetablesBehaviourManager
{
    public class VegetablesBehaviourManager : MonoBehaviour
    {
        [field:SerializeField] public VegSpawnerManager VegetableSpawner {get; private set;}
        [field:SerializeField] public Transform[] HidePoints {get; private set;}
        
        private Vector3 _direction;
        
        private void Awake()
        {
        }
    }
}
