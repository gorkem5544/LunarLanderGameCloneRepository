namespace Assembly_CSharp.Assets.Scripts.ManagerScripts.Abstracts
{
    public interface IScoreManager
    {
        void AddScore(int amount, int multipleValue = 1);
        void AddDeadScore(int amount);
        void AddDefaultScore(int amount);
        int Score { get; }
        System.Action<int> ScoreChanged { get; set; }
    }

}