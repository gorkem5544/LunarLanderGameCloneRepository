namespace Assembly_CSharp.Assets.Scripts.PlayerScripts.PlayerMovements.Abstracts
{
    public interface IPlayerFeedback
    {
        void PlayLaunchSound();
        void StopLaunchSound();
        void ActivateFireParticle();
        void DeactivateFireParticle();
    }

}