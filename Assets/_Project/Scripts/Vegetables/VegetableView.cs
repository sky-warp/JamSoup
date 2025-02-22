using _Project.Scripts.Infrastructure;
using _Project.Scripts.VegetableEntity;
using R3;
using UnityEngine;

namespace _Project.Scripts.Vegetables
{
    public class VegetableView : MonoBehaviour
    {
        [field:SerializeField] public Vegetable[] GoodVegetables { get; private set; }
        [field:SerializeField] public Vegetable[] BadVegetables { get; private set; }
        
        public Subject<VegetableModel> TransitVegetableModel { get; private set; }

        private VegetableController _vegetableController;

        public void Init(VegetableController vegetableController)
        {
            _vegetableController = vegetableController;

            TransitVegetableModel = new Subject<VegetableModel>();
        }

        public void CreateDroppedVegetable(Vegetable vegetable)
        {
            TransitVegetableModel.OnNext(_vegetableController.CreateNewVegetable(vegetable.Config));
        }
    }
}