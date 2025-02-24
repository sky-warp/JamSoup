using UnityEngine;

namespace _Project.Scripts.Configs
{
    public abstract class VegetableConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float Score { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public bool IsGood { get; private set; }
    }
}