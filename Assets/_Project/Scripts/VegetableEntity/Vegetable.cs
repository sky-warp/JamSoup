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
        public float Score { get; private set; }
        public bool IsGood { get; private set; }
        public bool IsReadyForMove { get; private set; }

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Speed = Config.Speed;
            Score = Config.Score;
            IsGood = Config.IsGood;
        }

        private void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        public void ObjectIsSpawned()
        {
            IsSpawned = true;
        }

        public void ReadyForMove()
        {
            IsReadyForMove = true;
        }
    }
}