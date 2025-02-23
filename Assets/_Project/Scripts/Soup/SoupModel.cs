using R3;

namespace _Project.Scripts.Soup
{
    public class SoupModel
    {
        public ReactiveProperty<int> CurrentScore { get; private set; }
        public ReactiveProperty<int> AddedScore { get; private set; }
        public ReactiveProperty<bool> WinComdition { get; private set; }
        public int MaxScore { get; private set; } = 1500;

        public SoupModel()
        {
            CurrentScore = new ReactiveProperty<int>(0);
            WinComdition = new ReactiveProperty<bool>(false);
            AddedScore = new ReactiveProperty<int>(0);
        }

        public void UpdateScore(int score)
        {
            AddedScore.Value = score;
            
            if (AddedScore.Value + score >= 0)
                CurrentScore.Value += score;

            CheckWin();

            /*if(CurrentScore.Value < 0)
                CurrentScore.Value = 0;*/
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