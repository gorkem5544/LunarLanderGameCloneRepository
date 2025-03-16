namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts
{
    public interface IPlayerForceUpMovement
    {
        void ApplyForceUp();
        void StopForceUp();
        void FixedTick();
        void UpdateTick();
    }
}