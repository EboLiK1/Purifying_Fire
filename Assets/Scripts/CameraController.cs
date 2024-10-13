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
        // ������������� ���� ��������� �������
        isTimeStopped = true;

        // ������� �������� �����
        yield return new WaitForSecondsRealtime(stopTime);

        // ��������������� �����
        Time.timeScale = 1f;

        // ���������� ���� ��������� �������
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
