using UnityEngine;

[CreateAssetMenu(fileName = "HealthConfig", menuName = "Entity Config/Health Config")]
public class HealthConfigSO : ScriptableObject
{
    [SerializeField] private int _initialHealth;

    public int InitialHealth => _initialHealth;
}
