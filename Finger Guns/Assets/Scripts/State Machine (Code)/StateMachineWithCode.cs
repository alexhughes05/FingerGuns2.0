using System;
using System.Collections.Generic;

public class StateMachineWithCode
{
    private IState _currentState;

    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> _currentTransitions = new List<Transition>();
    private List<Transition> _anyTransitions = new List<Transition>();

    private static readonly List<Transition> emptyTransitions = new List<Transition>(0); //creates empty list that all state machines can use

    public void Tick()
    {
        var transition = GetTransition();
        if (transition != null)
            SetState(transition.To); //current state will be set to whatever state the transition points to

        _currentState?.Tick(); //Executes the logic for what the current state is supposed to do.
    }

    public void SetState(IState state)
    {
        if (state == _currentState) //If trying to set to the same state, do nothing
            return;

        _currentState?.OnExit(); //First execute the onExit method on the state you were at
        _currentState = state;   //Set the current state to the new state

        _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions); //Tries to get all the transitions for the current state.
        if (_currentTransitions == null)                                            //If it doesn't have any, sets it to Empty
            _currentTransitions = emptyTransitions; //Dont want to create new lists

        _currentState.OnEnter(); //Finally execute the OnEnter method for the new state.
    }

    public void AddTransition(IState from, IState to, Func<bool> predicate)
    {
        if (_transitions.TryGetValue(from.GetType(), out var transitions) == false) //Look to see if the transition already exists
        {
            transitions = new List<Transition>(); //If it doesn't create it and add it's name as a key in the dictionary
            _transitions[from.GetType()] = transitions;
        }

        transitions.Add(new Transition(to, predicate)); //Set the value of the dictionary by adding the transition to the list
    }

    public void AddAnyTransition(IState state, Func<bool> predicate)
    {
        _anyTransitions.Add(new Transition(state, predicate));
    }

    private class Transition
    {
        public Func<bool> Condition { get; }
        public IState To { get; }

        public Transition(IState to, Func<bool> condition)
        {
            To = to;
            Condition = condition;
        }
    }

    private Transition GetTransition()
    {
        foreach (var transition in _anyTransitions) //First check the anyState transitions
            if (transition.Condition())
                return transition;

        foreach (var transition in _currentTransitions) //Next check normal transitions and return it if it satisfies the condition.
            if (transition.Condition())
                return transition;

        return null;
    }
}