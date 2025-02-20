using _Project.Scripts.Configs;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class Draggable : MonoBehaviour
    {
        [field: SerializeField] public VegetableConfig Config { get; private set; }
    }
}