using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.VegetableEntity
{
    [RequireComponent(typeof(Rigidbody))]
    public class Vegetable : MonoBehaviour
    {
        [field: SerializeField] public VegetableConfig Config { get; private set; }
        public Rigidbody Rigidbody { get; private set; }
        public bool IsSpawned { get; private set; }

        public float Speed { get; private set; }
        public bool IsGood { get; private set; }

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Speed = Config.Speed;
            IsGood = Config.IsGood;
        }

        public void ObjectIsSpawned()
        {
            IsSpawned = true;
        }
    }
}