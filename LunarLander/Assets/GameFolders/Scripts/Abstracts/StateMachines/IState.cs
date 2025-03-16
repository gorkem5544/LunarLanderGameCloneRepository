namespace Assembly_CSharp.Assets.Scripts.StateMachineScripts.Abstracts
{
    public interface IState
    {
        void EnterState();
        void ExitState();
        void UpdateState();
    }

}