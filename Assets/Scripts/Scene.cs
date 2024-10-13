using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    SceneSpawnPoints spawnPoints;

    private void Awake()
    {
        if (Game.CurrentSceneName != "")
            Game.Instance.PreviousSceneName = Game.CurrentSceneName;

        Game.CurrentSceneName = SceneManager.GetActiveScene().name;

        spawnPoints = GetComponent<SceneSpawnPoints>();

        GameObject playerObject = GameObject.FindWithTag("Player");

        string previousScene = Game.Instance.PreviousSceneName;

        // Проверяем каждую строку в массиве _sceneOutsideDoor
        for (int i = 0; i < spawnPoints.SceneOutsideDoor.Length; i++)
        {
            string sceneName = spawnPoints.SceneOutsideDoor[i];

            // Если название сцены сходится с предыдущей сценой
            if (sceneName == previousScene)
            {
                // Проверяем, есть ли точки спавна
                if (i < spawnPoints.SpawnPoints.Length)
                {
                    Transform spawnPoint = spawnPoints.SpawnPoints[i];

                    // Устанавливаем позицию игрока на найденную точку спавна
                    if (playerObject != null && spawnPoint != null)
                    {
                        playerObject.transform.position = spawnPoint.position;
                        playerObject.transform.rotation = spawnPoint.rotation;
                    }
                    else
                    {
                        Debug.LogError("Player object or spawn point is missing!");
                    }
                }
                else
                {
                    Debug.LogError("Spawn point index is out of range!");
                }

                // Прекращаем цикл после установки позиции игрока
                break;
            }
        }
    }
}