using _Project.Scripts.VegetableEntity;
using UnityEngine;

namespace _Project.Scripts.LevelBorder
{
    public class DestroyWhenOutOfBorder : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Vegetable>())
                Destroy(other.gameObject);
        }
    }
}