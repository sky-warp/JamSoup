using _Project.Scripts.Infrastructure;
using _Project.Scripts.Vegetables;
using R3;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Soup
{
    public class SoupView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private OnPotDrop _pot;

        private SoupViewModel _viewModel;
        private VegetableView _vegetableView;
        private CompositeDisposable _disposable = new();

        public void Init(SoupViewModel viewModel, VegetableView vegetableView)
        {
            _viewModel = viewModel;
            _vegetableView = vegetableView;

            _pot.OnPotDropped
                .Subscribe(_vegetableView.CreateDroppedVegetable)
                .AddTo(_disposable);

            vegetableView.TransitVegetableModel
                .Subscribe(vegetable => _viewModel.Vegetable.Value = vegetable)
                .AddTo(_disposable);

            _viewModel.ViewScore
                .Subscribe(UpdateViewScore)
                .AddTo(_disposable);
        }

        private void UpdateViewScore(int score)
        {
            _text.text = score.ToString();
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();
        }
    }
}