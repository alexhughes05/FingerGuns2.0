using UnityEngine;

namespace FingerGuns.StateMachine.ScriptableObjects
{
	/// <summary>
	/// Base class for StateMachine ScriptableObjects that need a public description field.
	/// </summary>
	public class DescriptionSMActionBaseSO : ScriptableObject
	{
		[TextArea(1, 7)] 
		public string description;
	}

}