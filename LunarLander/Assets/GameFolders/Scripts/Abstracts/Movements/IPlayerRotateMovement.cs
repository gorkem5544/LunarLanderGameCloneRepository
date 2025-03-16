namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts
{
    public interface IPlayerRotateMovement
    {
        void FixedUpdateTick();
        void UpdateTick();
        void RotatePlayer(float rotationDirection);
    }
}