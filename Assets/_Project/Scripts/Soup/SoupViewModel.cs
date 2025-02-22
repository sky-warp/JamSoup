using _Project.Scripts.Vegetables;
using R3;

namespace _Project.Scripts.Soup
{
    public class SoupViewModel
    {
        public ReactiveProperty<int> ViewScore { get; private set; }
        public ReactiveProperty<VegetableModel> Vegetable { get; private set; }

        private SoupModel _soupModel;
        private CompositeDisposable _disposable;

        public SoupViewModel(SoupModel soupModel)
        {
            _soupModel = soupModel;

            Vegetable = new ReactiveProperty<VegetableModel>();
            Vegetable.Subscribe(UpdateModelScore);

            ViewScore = _soupModel.CurrentScore;
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