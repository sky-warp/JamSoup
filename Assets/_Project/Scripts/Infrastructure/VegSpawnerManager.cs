using System;
using System.Collections;
using _Project.Scripts.VegetableEntity;
using _Project.Scripts.Vegetables;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Infrastructure
{
    public class VegSpawnerManager : MonoBehaviour
    {
        public Vegetable[] GoodVegetables { get; private set; }
        public Vegetable[] BadVegetables { get; private set; }
        public Action<Vegetable> OnSpawnedVegetable;

        [SerializeField] private Collider[] _spawnArea;
        [SerializeField] private float _badSpawnChance;
        [SerializeField] private float _maxSpawnIntervalValue;

        private Vector3 _randomPoint;
        private bool _pointFound;
        private float _elapsedTime;

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
            GoodVegetables = vegetableView.GoodVegetables;
            BadVegetables = vegetableView.BadVegetables;

            ShuffleArray(GoodVegetables);
            ShuffleArray(BadVegetables);
        }

        public Vector3 GetRandomPointOnSurface()
        {
            _pointFound = false;

            int randomIndex = Random.Range(0, _spawnArea.Length);
            Bounds bounds = _spawnArea[randomIndex].bounds;

            while (!_pointFound)
            {
                float randomX = Random.Range(bounds.min.x, bounds.max.x);
                float randomY = Random.Range(bounds.min.y, bounds.max.y);
                float randomZ = Random.Range(bounds.min.z, bounds.max.z);

                Ray ray = new Ray(new Vector3(randomX, randomY, randomZ), Vector3.down);

                if (_spawnArea[randomIndex].Raycast(ray, out RaycastHit hit, bounds.size.y))
                {
                    _randomPoint = hit.point;
                    _pointFound = true;
                    return _randomPoint;
                }
            }

            return Vector3.zero;
        }

        public IEnumerator SpawnVeg()
        {
            while (_elapsedTime <= 180.0f)
            {
                if (_elapsedTime >= 60.0f)
                {
                    _badSpawnChance *= 2;
                    _maxSpawnIntervalValue /= 2;
                }

                _elapsedTime += 1;

                float spawnTime = Random.Range(0f, _maxSpawnIntervalValue);


                bool isSpawnBad = Random.value <= _badSpawnChance;

                if (isSpawnBad)
                {
                    int randomIndex = Random.Range(0, BadVegetables.Length);
                    var currentVegGameObj = Instantiate(BadVegetables[randomIndex].gameObject, GetRandomPointOnSurface(),
                        Quaternion.identity);

                    var currentVeg = currentVegGameObj.GetComponent<Vegetable>();
                    currentVeg.ObjectIsSpawned();
                    OnSpawnedVegetable?.Invoke(currentVeg);
                }
                else
                {
                    int randomIndex = Random.Range(0, GoodVegetables.Length);
                    var currentVegGameObj = Instantiate(GoodVegetables[randomIndex].gameObject, GetRandomPointOnSurface(),
                        Quaternion.identity);

                    var currentVeg = currentVegGameObj.GetComponent<Vegetable>();
                    currentVeg.ObjectIsSpawned();
                    OnSpawnedVegetable?.Invoke(currentVeg);
                }

                yield return new WaitForSeconds(spawnTime);
            }
        }

        private void ShuffleArray<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                var temp = array[i];
                int n = Random.Range(i, array.Length);
                array[i] = array[n];
                array[n] = temp;
            }
        }
    }
}