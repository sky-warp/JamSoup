using R3;

namespace _Project.Scripts.Soup
{
    public class SoupModel
    {
        public ReactiveProperty<int> CurrentScore { get; private set; }

        public SoupModel()
        {
            CurrentScore = new ReactiveProperty<int>(0);
        }

        public void UpdateScore(int score)
        {
            if (CurrentScore.Value + score >= 0)
                CurrentScore.Value += score;
        }
    }
}