using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "FlashEffectAction", menuName = "State Machines/Actions/Flash Effect Action")]
public class FlashEffectActionSO : StateActionSO
{
	//inspector
	[Header("Material Swap Settings")]
	[SerializeField] private Material _newMaterial;
	[SerializeField] private float _swapDuration;
	[SerializeField] private int _numOfSwaps;
	[SerializeField] private float _timeBtwSwaps;
	protected override StateAction CreateAction() => new FlashEffectAction(_newMaterial, _swapDuration, _timeBtwSwaps, _numOfSwaps);
}

public class FlashEffectAction : StateAction
{
	private readonly Material _newMaterial;
	private readonly float _swapDuration;
	private readonly float _timeBtwSwaps;
	private readonly int _numOfSwaps;

	private MaterialModifier _materialSwapper;
	private float nextSwapTime;
	private int currentSwapNum;

	public FlashEffectAction(Material newMaterial, float swapDuration, float timeBtwSwaps, int numOfSwaps)
    {
		_newMaterial = newMaterial;
		_swapDuration = swapDuration;
		_timeBtwSwaps = timeBtwSwaps;
		_numOfSwaps = numOfSwaps;
    }

	public override void Awake(StateMachine stateMachine)
	{
		stateMachine.TryGetComponent(out _materialSwapper);
		if (_materialSwapper == null)
			Debug.LogError("FlashEffectActionSO was unable to find the MaterialSwapper component on gameobject " + stateMachine.gameObject.name);
	}
	
	public override void OnUpdate()
	{
		if (currentSwapNum <= _numOfSwaps)
        {
			if (nextSwapTime <= Time.time)
            {
				_materialSwapper.SwapMaterialForDuration(_newMaterial, _swapDuration);
				nextSwapTime = Time.time + _swapDuration + _timeBtwSwaps;
				currentSwapNum++;
			}
		}
	}
	
	public override void OnStateEnter()
	{
        _materialSwapper.SwapMaterialForDuration(_newMaterial, _swapDuration);
		nextSwapTime = Time.time + _swapDuration + _timeBtwSwaps;
		currentSwapNum = 2;
    }
	
	public override void OnStateExit()
	{
	}
}
