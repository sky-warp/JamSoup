using R3;

namespace _Project.Scripts.Soup
{
    public class SoupModel
    {
        public ReactiveProperty<int> CurrentScore { get; private set; }
        public ReactiveProperty<bool> WinComdition { get; private set; }
        public int MaxScore { get; private set; } = 1000;

        public SoupModel()
        {
            CurrentScore = new ReactiveProperty<int>(0);
            WinComdition = new ReactiveProperty<bool>(false);
        }

        public void UpdateScore(int score)
        {
            CurrentScore.Value += score;
            CheckWin();
            
            if(CurrentScore.Value < 0)
                CurrentScore.Value = 0;
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