﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FingerGuns.StateMachine.ScriptableObjects
{
	[CreateAssetMenu(fileName = "New Transition Table", menuName = "State Machines/Transition Table")]
	public class TransitionTableSO : ScriptableObject
	{
		[SerializeField] private TransitionItem[] _transitions = default;

		public Dictionary<ScriptableObject, object> CreatedInstances { get; private set; }

		/// <summary>
		/// Will get the initial state and instantiate all subsequent states, transitions, actions and conditions.
		/// </summary>
		internal State GetInitialState(StateMachine stateMachine)
		{
			var states = new List<State>();
			var transitions = new List<StateTransition>();
			var createdInstances = new Dictionary<ScriptableObject, object>();

			var fromStates = _transitions.GroupBy(transition => transition.FromState);

			foreach (var fromState in fromStates)
			{
				if (fromState.Key == null)
					throw new ArgumentNullException(nameof(fromState.Key), $"TransitionTable: {name}");

				var state = fromState.Key.GetState(stateMachine, createdInstances);
				states.Add(state);

				transitions.Clear(); //This is inside a foreach loop for each from state. When you go to the next state, you want to clear the transitions from the last state before adding again.
				foreach (var transitionItem in fromState)
				{
					if (transitionItem.ToState == null)
						throw new ArgumentNullException(nameof(transitionItem.ToState), $"TransitionTable: {name}, From State: {fromState.Key.name}");

					var toState = transitionItem.ToState.GetState(stateMachine, createdInstances);
					ProcessConditionUsages(stateMachine, transitionItem.Conditions, createdInstances, out var conditions, out var resultGroups);
					transitions.Add(new StateTransition(toState, conditions, resultGroups));
				}

				state._transitions = transitions.ToArray();
			}
			CreatedInstances = createdInstances;

			return states.Count > 0 ? states[0]
				: throw new InvalidOperationException($"TransitionTable {name} is empty.");
		}

		private static void ProcessConditionUsages(
			StateMachine stateMachine,
			ConditionUsage[] conditionUsages,
			Dictionary<ScriptableObject, object> createdInstances,
			out StateCondition[] conditions,
			out int[] resultGroups)
		{
			int count = conditionUsages.Length; //number of conditions
			conditions = new StateCondition[count]; //create and set all the conditions defined in inspector
			for (int i = 0; i < count; i++)
				conditions[i] = conditionUsages[i].Condition.GetCondition(
					stateMachine, conditionUsages[i].ExpectedResult == Result.True, createdInstances);


			List<int> resultGroupsList = new List<int>();
			for (int i = 0; i < count; i++) //Go through all conditions
			{
				int idx = resultGroupsList.Count; //index for which transition you are at. Number shows how much conditions there are to evaluate in each transition
				resultGroupsList.Add(1);
				while (i < count - 1 && conditionUsages[i].Operator == Operator.And)
				{
					i++;
					resultGroupsList[idx]++;
				}
			}

			resultGroups = resultGroupsList.ToArray();
		}

		[Serializable]
		public struct TransitionItem
		{
			public StateSO FromState;
			public StateSO ToState;
			public ConditionUsage[] Conditions;
		}

		[Serializable]
		public struct ConditionUsage
		{
			public Result ExpectedResult;
			public StateConditionSO Condition;
			public Operator Operator;
		}

		public enum Result { True, False }
		public enum Operator { And, Or }
	}
}
