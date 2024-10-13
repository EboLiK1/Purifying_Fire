using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    #region Музыка
    public AudioClip MainMenu;
    public AudioClip Title;
    public AudioClip Levels;
    public AudioClip Boss;
    #endregion

    public float Value;

    private AudioSource _audioSource;
    [SerializeField] private float fadeDuration = 2f; // Длительность плавного появления музыки

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0f;
        int saveVolume = PlayerPrefs.GetInt("MusicVolume", 10);
        Value = saveVolume / 10f;
        PlayMainSound();
    }

    public void PlayMainSound()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
            _audioSource.clip = MainMenu;
        else if(SceneManager.GetActiveScene().name == "Title")
            _audioSource.clip = Title;
        else if (SceneManager.GetActiveScene().name == "Cathedral_1" ||
                 SceneManager.GetActiveScene().name == "Cathedral_2" ||
                 SceneManager.GetActiveScene().name == "Cathedral_3" ||
                 SceneManager.GetActiveScene().name == "Cathedral_4" ||
                 SceneManager.GetActiveScene().name == "Caves_1" ||
                 SceneManager.GetActiveScene().name == "Caves_2")
        {
            if (_audioSource.clip != Levels)
            {
                _audioSource.clip = Levels;
            }
        }
        else if(SceneManager.GetActiveScene().name == "Boss_room")
            _audioSource.clip = Boss;

        _audioSource.Play();
        StartCoroutine(FadeInMusic());
    }

    public void ChangeSound(float value)
    {
        _audioSource.volume = value;
        PlayerPrefs.SetInt("MusicVolume", Convert.ToInt32(_audioSource.volume * 10));
    }


    IEnumerator FadeInMusic()
    {
        float timer = 0f;
        float startVolume = _audioSource.volume;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(startVolume, Value, timer / fadeDuration);
            yield return null;
        }

        _audioSource.volume = Value; // Установка окончательной громкости на 1
    }
}