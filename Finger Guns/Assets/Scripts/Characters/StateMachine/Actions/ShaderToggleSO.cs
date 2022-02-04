using UnityEngine;
using FingerGuns.StateMachine;
using FingerGuns.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ShaderToggle", menuName = "State Machines/Actions/Shader Toggle")]
public class ShaderToggleSO : StateActionSO
{
    [Space]
    [SerializeField] private string nameId;
    [Space]
    [SerializeField] private float toggleDuration;
    [Space]
    [SerializeField] private float timeBtwToggles;
    [Space]
    [SerializeField] private int numOfToggles;
    protected override StateAction CreateAction() => new ShaderToggle(nameId, toggleDuration, timeBtwToggles, numOfToggles);
}

public class ShaderToggle : StateAction
{
    private readonly string _nameId;
    private readonly float _toggleDuration;
    private readonly float _timeBtwToggles;
    private readonly int _numOfToggles;

    private MaterialModifier _materialModifier;
    private float nextToggleTime;
    private int currentToggleNum;
    public ShaderToggle(string nameId, float toggleDuration, float timeBtwToggles, int numOfToggles)
    {
        _nameId = nameId;
        _toggleDuration = toggleDuration;
        _timeBtwToggles = timeBtwToggles;
        _numOfToggles = numOfToggles;
    }

    public override void Awake(StateMachine stateMachine)
    {
        stateMachine.TryGetComponent(out _materialModifier);
        if (_materialModifier == null)
            Debug.LogError("ShaderToggleSO was unable to find the MaterialModifier component on gameobject " + stateMachine.gameObject.name);
    }

    public override void OnUpdate()
    {
        if (currentToggleNum <= _numOfToggles)
        {
            if (nextToggleTime <= Time.time)
            {
                _materialModifier.StartCoroutine(_materialModifier.ToggleMaterialForDuration(_nameId, _toggleDuration));

                nextToggleTime = Time.time + _toggleDuration + _timeBtwToggles;
                currentToggleNum++;
            }
        }
        else
            _materialModifier.ExecuteIFrames = false;
    }

    public override void OnStateEnter()
    {
        _materialModifier.StartCoroutine(_materialModifier.ToggleMaterialForDuration(_nameId, _toggleDuration));
        nextToggleTime = Time.time + _toggleDuration + _timeBtwToggles;
        currentToggleNum = 2;
    }
}
