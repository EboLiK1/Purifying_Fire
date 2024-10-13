using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    #region Звуки UI
    public AudioClip _buttonPress;
    public AudioClip _closeMenu;
    public AudioClip _openMenu;
    #endregion

    #region Звуки диалогов
    public AudioClip PlayerTypeText;
    public AudioClip EnemyTypeText;
    #endregion

    public float Value;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _audioSource = GetComponent<AudioSource>();

        int saveVolume = PlayerPrefs.GetInt("EffectsVolume", 10);
        Value = saveVolume / 10f;
    }

    public void ChangeEffectsVolume(float value)
    {
        _audioSource.volume = value;
        PlayerPrefs.SetInt("EffectsVolume", Convert.ToInt32(_audioSource.volume * 10));
    }

    public void PlayButtonSelectSound() =>
        _audioSource.PlayOneShot(_buttonPress);

    public void PlayPressButtonSound() =>
        _audioSource.PlayOneShot(_openMenu);

    public void PlayCloseMenuSound() =>
        _audioSource.PlayOneShot(_closeMenu);

    public void PlayTypeTextSound(string text)
    {
        if (text == nameof(PlayerTypeText))
            _audioSource.PlayOneShot(PlayerTypeText);
        else if (text == nameof(EnemyTypeText))
            _audioSource.PlayOneShot(EnemyTypeText);
    }

    public void PlayTypeSound() =>
        _audioSource.PlayOneShot(EnemyTypeText);
}