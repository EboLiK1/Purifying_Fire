using UnityEngine;

[CreateAssetMenu(fileName = "NewIdleData", menuName = "Data/State Data/Idle Data")]
public class IdleStateData : ScriptableObject
{
    [SerializeField] private float _minIdleTime;
    [SerializeField] private float _maxIdleTime;

    public float MinIdleTime => _minIdleTime;
    public float MaxIdleTime => _maxIdleTime;
}