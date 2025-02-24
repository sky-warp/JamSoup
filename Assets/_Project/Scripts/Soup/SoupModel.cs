using R3;

namespace _Project.Scripts.Soup
{
    public class SoupModel
    {
        public ReactiveProperty<float> CurrentScore { get; private set; }
        public ReactiveProperty<float> AddedScore { get; private set; }
        public ReactiveProperty<bool> WinComdition { get; private set; }
        public int MaxScore { get; private set; } = 3000;

        public SoupModel()
        {
            CurrentScore = new ReactiveProperty<float>(0);
            WinComdition = new ReactiveProperty<bool>(false);
            AddedScore = new ReactiveProperty<float>(0);
        }

        public void UpdateScore(float score)
        {
            AddedScore.Value = score;

            if (CurrentScore.Value + score >= 0)
                CurrentScore.Value += score;
            
            CheckWin();
        }

        private void CheckWin()
        {
            if (CurrentScore.Value >= MaxScore)
            {
                WinComdition.Value = true;
            }
        }
    }
}