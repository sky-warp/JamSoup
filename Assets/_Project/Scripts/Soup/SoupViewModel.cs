using _Project.Scripts.Vegetables;
using R3;

namespace _Project.Scripts.Soup
{
    public class SoupViewModel
    {
        public ReactiveProperty<int> ScoreView { get; private set; }
        public ReactiveProperty<VegetableModel> Vegetable { get; private set; }
        public ReactiveProperty<bool> WinConditionView { get; private set; }

        public float MaxScoreView { get; private set; }

        private SoupModel _soupModel;
        private CompositeDisposable _disposable;

        public SoupViewModel(SoupModel soupModel)
        {
            _soupModel = soupModel;
            MaxScoreView = _soupModel.MaxScore;

            Vegetable = new ReactiveProperty<VegetableModel>();
            Vegetable.Subscribe(UpdateModelScore);

            WinConditionView = new ReactiveProperty<bool>();
            WinConditionView = _soupModel.WinComdition;
            
            ScoreView = _soupModel.CurrentScore;
        }

        private void UpdateModelScore(VegetableModel obj)
        {
            if (Vegetable.Value != null)
            {
                int score = Vegetable.Value.Score;
                _soupModel.UpdateScore(score);
            }
        }

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}