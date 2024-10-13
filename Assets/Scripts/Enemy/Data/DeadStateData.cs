using UnityEngine;

[CreateAssetMenu(fileName = "NewDeadData", menuName = "Data/State Data/Dead Data")]
public class DeadStateData : ScriptableObject
{
    [SerializeField] private GameObject _bloodParticle;

    public GameObject BloodParticle => _bloodParticle;
}
