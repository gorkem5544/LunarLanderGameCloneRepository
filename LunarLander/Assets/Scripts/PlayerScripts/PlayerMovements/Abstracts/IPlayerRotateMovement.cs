namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts
{
    public interface IPlayerRotateMovement
    {
        void FixedUpdateRotation();
        void RotatePlayer(float rotationDirection);
    }
}