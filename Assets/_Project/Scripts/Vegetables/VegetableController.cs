using _Project.Scripts.Configs;

namespace _Project.Scripts.Vegetables
{
    public class VegetableController
    {
        private VegetableModel _vegetableModel;
        
        public VegetableController(VegetableModel vegetableModel)
        {
            _vegetableModel = vegetableModel;
        }

        public VegetableModel CreateNewVegetable(VegetableConfig config)
        {
            VegetableModel newVegetable = new VegetableModel();
            
            newVegetable = newVegetable.CreateNewVeg(config);
            
            return newVegetable;
        }
    }
}