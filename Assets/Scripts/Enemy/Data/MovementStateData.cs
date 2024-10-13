using UnityEngine;

[CreateAssetMenu(fileName = "NewMovementData", menuName = "Data/State Data/Movement Data")]
public class MovementStateData : ScriptableObject
{
    [SerializeField] private float _moveSpeed;

    public float MoveSpeed => _moveSpeed;
}
