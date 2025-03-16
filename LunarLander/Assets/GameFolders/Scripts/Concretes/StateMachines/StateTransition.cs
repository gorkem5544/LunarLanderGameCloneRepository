using System;
using Assembly_CSharp.Assets.Scripts.StateMachineScripts.Abstracts;

namespace Assembly_CSharp.Assets.Scripts.StateMachineScripts.Concretes
{
    public class StateTransition
{
    public IState From { get; }
    public IState To { get; }
    public Func<bool> Condition { get; }

    public StateTransition(IState from, IState to, Func<bool> condition)
    {
        From = from;
        To = to;
        Condition = condition;
    }
}

}