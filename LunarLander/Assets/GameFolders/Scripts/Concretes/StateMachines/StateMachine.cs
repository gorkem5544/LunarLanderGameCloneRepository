using System;
using System.Collections.Generic;
using Assembly_CSharp.Assets.Scripts.EnumScripts;
using Assembly_CSharp.Assets.Scripts.StateMachineScripts.Abstracts;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.StateMachineScripts.Concretes
{
    public class StateMachine
{
    private List<StateTransition> _stateTransitions = new List<StateTransition>();
    private List<StateTransition> _anyStateTransitions = new List<StateTransition>();
    private IState _currentState;
    private Dictionary<GameManagerStateEnum, IState> _states = new Dictionary<GameManagerStateEnum, IState>();

    public void AddState(GameManagerStateEnum stateEnum, IState state)
    {
        _states[stateEnum] = state;
    }

    public void SetInitialState(GameManagerStateEnum initialState)
    {
        if (_states.TryGetValue(initialState, out var state))
        {
            _currentState = state;
            _currentState.EnterState();
        }
        else
        {
            Debug.LogError($"Initial state '{initialState}' not found in the state machine.");
        }
    }

    public void SetState(IState state)
    {
        if (_currentState == state)
        {
            return;
        }

        _currentState?.ExitState();
        _currentState = state;
        _currentState.EnterState();
    }
    public void TransitionToState(GameManagerStateEnum stateEnum)
    {
        if (_states.TryGetValue(stateEnum, out var newState))
        {
            _currentState.ExitState();
            _currentState = newState;
            _currentState.EnterState();
        }
        else
        {
            Debug.LogError($"State '{stateEnum}' not found in the state machine.");
        }
    }

    public void Update()
    {
        var transition = CheckForTransition();
        if (transition != null)
        {
            SetState(transition.To);
        }
        _currentState?.UpdateState();
    }

    private StateTransition CheckForTransition()
    {
        foreach (var anyTransition in _anyStateTransitions)
        {
            if (anyTransition.Condition())
            {
                return anyTransition;
            }
        }
        foreach (var transition in _stateTransitions)
        {
            if (transition.Condition() && transition.From == _currentState)
            {
                return transition;
            }
        }
        return null;
    }

    public void AddTransition(IState from, IState to, Func<bool> condition)
    {
        var transition = new StateTransition(from, to, condition);
        _stateTransitions.Add(transition);
    }

    public void AddAnyStateTransition(IState to, Func<bool> condition)
    {
        var transition = new StateTransition(null, to, condition);
        _anyStateTransitions.Add(transition);
    }
}

}