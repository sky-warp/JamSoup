using _Project.Scripts.Infrastructure;
using R3;
using UnityEngine;

namespace _Project.Scripts.Vegetables
{
    public class VegetableView : MonoBehaviour
    {
        [field:SerializeField] public Draggable[] GoodVegetables { get; private set; }
        [field:SerializeField] public Draggable[] BadVegetables { get; private set; }
        
        public Subject<VegetableModel> TransitVegetableModel { get; private set; }

        private VegetableController _vegetableController;

        public void Init(VegetableController vegetableController)
        {
            _vegetableController = vegetableController;

            TransitVegetableModel = new Subject<VegetableModel>();
        }

        public void CreateDroppedVegetable(Draggable vegetable)
        {
            TransitVegetableModel.OnNext(_vegetableController.CreateNewVegetable(vegetable.Config));
        }
    }
}