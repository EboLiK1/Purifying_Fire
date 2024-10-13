using UnityEngine;

[CreateAssetMenu(fileName = "NewChargeData", menuName = "Data/State Data/Charge Data")]
public class ChargeStateData : ScriptableObject
{
    [SerializeField] private float _chargeSpeed;

    public float ChargeSpeed => _chargeSpeed;
}
