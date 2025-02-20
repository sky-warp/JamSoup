using System.Collections;
using _Project.Scripts.Vegetables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Infrastructure
{
    public class VegSpawner : MonoBehaviour
    {
        public Draggable[] Vegetables { get; private set; }

        [SerializeField] private Collider _spawnArea;

        private Vector3 randomPoint;
        private bool pointFound;

        private void Start()
        {
            StartCoroutine(SpawnVeg());
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        public void Init(VegetableView vegetableView)
        {
            Vegetables = vegetableView.Vegetables;
        }

        public Vector3 GetRandomPointOnSurface()
        {
            pointFound = false;

            Bounds bounds = _spawnArea.bounds;

            while (!pointFound)
            {
                float randomX = Random.Range(bounds.min.x, bounds.max.x);
                float randomY = Random.Range(bounds.min.y, bounds.max.y);
                float randomZ = Random.Range(bounds.min.z, bounds.max.z);

                Ray ray = new Ray(new Vector3(randomX, randomY, randomZ), Vector3.down);

                if (_spawnArea.Raycast(ray, out RaycastHit hit, bounds.size.y))
                {
                    randomPoint = hit.point;
                    pointFound = true;
                    return randomPoint;
                }
            }

            return Vector3.zero;
        }

        public IEnumerator SpawnVeg()
        {
            bool enough = false;
            int count = 0;

            while (!enough)
            {
                if (count == 10)
                    enough = true;

                count++;

                var randomVegIndex = Random.Range(0, Vegetables.Length);

                Instantiate(Vegetables[randomVegIndex], GetRandomPointOnSurface(), Quaternion.identity);

                yield return new WaitForSeconds(1f);
            }
        }
    }
}