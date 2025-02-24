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
        [SerializeField] private OnBadVegetableDrop _badVegetableDropArea;
        [SerializeField] private VegSpawnerManager _spawnManager;
        [SerializeField] private GameObject _endGameWindow;
        [SerializeField] private TextMeshProUGUI _finalScoreText;

        private SoupViewModel _viewModel;
        private VegetableView _vegetableView;
        private CompositeDisposable _disposable = new();
        private float _maxScore;

        public void Init(SoupViewModel viewModel, VegetableView vegetableView)
        {
            _viewModel = viewModel;
            _vegetableView = vegetableView;

            _maxScore = _viewModel.MaxScoreView;

            _pot.OnPotDropped
                .Subscribe(_vegetableView.CreateDroppedVegetable)
                .AddTo(_disposable);

            _badVegetableDropArea.OnBadVegetableDroped
                .Subscribe(UpdateHealth)
                .AddTo(_disposable);

            vegetableView.TransitVegetableModel
                .Subscribe(vegetable => _viewModel.Vegetable.Value = vegetable)
                .AddTo(_disposable);

            _viewModel.ScoreView
                .Subscribe(UpdateHealth)
                .AddTo(_disposable); 
            
            _viewModel.AddedScoreView
                .Subscribe(UpdateHealth)
                .AddTo(_disposable);

            _spawnManager.OnGameEnded += GameEnd;
        }

        private void UpdateHealth(float score)
        {
            _healthBarImage.fillAmount += score / _maxScore;
        }

        private void GameEnd()
        {
            _endGameWindow.SetActive(true);
            _finalScoreText.text = $"Final score: {_viewModel.ScoreView}";
        }
        
        private void OnDestroy()
        {
            _disposable?.Dispose();
            _spawnManager.OnGameEnded -= GameEnd;
        }
    }
}