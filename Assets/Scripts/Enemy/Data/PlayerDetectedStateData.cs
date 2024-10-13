using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerDetectedData", menuName = "Data/State Data/Player Detected Data")]
public class PlayerDetectedStateData : ScriptableObject
{
    [SerializeField] private float _longRangeAction;
    [SerializeField] private float _closeRangeAction;
    
    public float LongRangeAction => _longRangeAction;
    public float CloseRangeAction => _closeRangeAction;
}
