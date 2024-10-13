using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vCamera;
    [SerializeField] float Amplitude;
    [SerializeField] float Frequency;

    public float stopTime = 0.5f;
    public bool isTimeStopped = false;


    public IEnumerator WaitForTimeStop()
    {
        // Устанавливаем флаг остановки времени
        isTimeStopped = true;

        // Ожидаем заданное время
        yield return new WaitForSecondsRealtime(stopTime);

        // Восстанавливаем время
        Time.timeScale = 1f;

        // Сбрасываем флаг остановки времени
        isTimeStopped = false;
    }

    public void Shake()
    {
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Amplitude;
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = Frequency;

        Invoke("DisableShake", stopTime);
    }

    public void DisableShake()
    {
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
        vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0;
    }
}
