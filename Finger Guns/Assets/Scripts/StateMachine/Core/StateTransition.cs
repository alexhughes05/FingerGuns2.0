namespace FingerGuns.StateMachine
{
	public class StateTransition : IStateComponent
	{
		public State TargetState { get; private set; }

		private State _targetState;
		private StateCondition[] _conditions;
		private int[] _resultGroups;
		private bool[] _results;

		internal StateTransition() { }
		public StateTransition(State targetState, StateCondition[] conditions, int[] resultGroups = null)
		{
			Init(targetState, conditions, resultGroups);
		}

		internal void Init(State targetState, StateCondition[] conditions, int[] resultGroups = null)
		{
			_targetState = targetState;
			_conditions = conditions;
			_resultGroups = resultGroups != null && resultGroups.Length > 0 ? resultGroups : new int[1];
			_results = new bool[_resultGroups.Length];
		}

		/// <summary>
		/// Checks wether the conditions to transition to the target state are met.
		/// </summary>
		/// <param name="state">Returns the state to transition to. Null if the conditions aren't met.</param>
		/// <returns>True if the conditions are met.</returns>
		public bool TryGetTransiton(out State state)
		{
			state = ShouldTransition() ? _targetState : null;
			TargetState = _targetState;
			return state != null;
		}

		public void OnStateEnter()
		{
			for (int i = 0; i < _conditions.Length; i++)
				_conditions[i]._condition.OnStateEnter();
		}

		public void OnStateExit()
		{
			for (int i = 0; i < _conditions.Length; i++)
				_conditions[i]._condition.OnStateExit();
		}

		private bool ShouldTransition() //True if there is a single transition a state can go to.
		{
#if UNITY_EDITOR
			_targetState._stateMachine._debugger.TransitionEvaluationBegin(_targetState._originSO.name);
#endif

			int count = _resultGroups.Length; //number of transitions
			for (int i = 0, idx = 0; i < count && idx < _conditions.Length; i++) //i is the current transition you're at. j is a marker for the current condition to decide if you should transition
				for (int j = 0; j < _resultGroups[i]; j++, idx++)
					_results[i] = j == 0 ?
						_conditions[idx].IsMet() :
						_results[i] && _conditions[idx].IsMet();

			bool ret = false;
			for (int i = 0; i < count && !ret; i++) //if any of the results become true, ShouldTransition is true
				ret = ret || _results[i];

#if UNITY_EDITOR
			_targetState._stateMachine._debugger.TransitionEvaluationEnd(ret, _targetState._actions);
#endif
			return ret;
		}

		internal void ClearConditionsCache()
		{
			for (int i = 0; i < _conditions.Length; i++)
				_conditions[i]._condition.ClearStatementCache();
		}
	}
}
