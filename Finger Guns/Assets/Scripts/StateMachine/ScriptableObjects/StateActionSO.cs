using System.Collections.Generic;
using UnityEngine;

namespace FingerGuns.StateMachine.ScriptableObjects
{
	public abstract class StateActionSO : ScriptableObject
	{
		/// <summary>
		/// Will create a new custom <see cref="StateAction"/> or return an existing one inside <paramref name="createdInstances"/>
		/// </summary>
		public StateAction GetAction(StateMachine stateMachine, Dictionary<ScriptableObject, object> createdInstances)
		{
			if (createdInstances.TryGetValue(this, out var obj))
				return (StateAction)obj;

			var action = CreateAction();
			createdInstances.Add(this, action);
			action._originSO = this;
			action.Awake(stateMachine);
			return action;
		}
		protected abstract StateAction CreateAction();

        public static implicit operator List<object>(StateActionSO v)
        {
            throw new System.NotImplementedException();
        }
    }

	public abstract class StateActionSO<T> : StateActionSO where T : StateAction, new()
	{
		protected override StateAction CreateAction() => new T();
	}
}
