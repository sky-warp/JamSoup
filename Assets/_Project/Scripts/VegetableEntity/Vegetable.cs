using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.VegetableEntity
{
    public class Vegetable : MonoBehaviour
    {
        [field: SerializeField] public VegetableConfig Config { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        
        public bool IsSpawned { get; private set; }

        public void ObjectIsSpawned()
        {
            IsSpawned = true;
        }
    }
}