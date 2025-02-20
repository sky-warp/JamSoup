using UnityEngine;

namespace _Project.Scripts.Configs
{
    public abstract class VegetableConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Score { get; private set; }
    }
}