using _Project.Scripts.Soup;
using _Project.Scripts.Vegetables;
using UnityEngine;

namespace _Project.Scripts.Infrastructure
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private SoupView _soupView;
        [SerializeField] private VegetableView _vegetableView;
        [SerializeField] private VegSpawner _vegSpawner;

        private SoupViewModel soupViewModel;

        private void Awake()
        {
            VegetableModel vegetableModel = new();
            VegetableController vegetableController = new(vegetableModel);
            _vegetableView.Init(vegetableController);

            SoupModel soupModel = new SoupModel();
            soupViewModel = new SoupViewModel(soupModel);
            _soupView.Init(soupViewModel, _vegetableView);

            _vegSpawner.Init(_vegetableView);
        }

        private void OnDestroy()
        {
            soupViewModel.Dispose();
        }
    }
}