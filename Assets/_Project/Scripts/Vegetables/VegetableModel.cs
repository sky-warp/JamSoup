using _Project.Scripts.Configs;

namespace _Project.Scripts.Vegetables
{
    public class VegetableModel
    {
        public int Score { get; private set; }
        
        public VegetableModel CreateNewVeg(VegetableConfig config)
        {
            VegetableModel vegetableModel = new VegetableModel();
            
            vegetableModel.Score = config.Score;
            
            return vegetableModel;
        }
    }
}