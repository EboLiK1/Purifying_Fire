using UnityEngine;

public class SceneSpawnPoints : MonoBehaviour
{
    [SerializeField] private string[] _sceneOutsideDoor;
    [SerializeField] private Transform[] _spawnPoints;

    public string[] SceneOutsideDoor => _sceneOutsideDoor;
    public Transform[] SpawnPoints => _spawnPoints;


}