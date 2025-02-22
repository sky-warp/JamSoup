using _Project.Scripts.Infrastructure;
using _Project.Scripts.Vegetables;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Soup
{
    public class SoupView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _healthBarImage;
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
            if (score < 0)
            {
                UpdateHealth(Mathf.Abs(score));
            }
            
            _text.text = score.ToString();
        }
        private void UpdateHealth(int score)
        {
            _healthBarImage.fillAmount -= score / 100f;
        }

        private void OnDestroy()
        {
            _disposable?.Dispose();
        }
    }
}