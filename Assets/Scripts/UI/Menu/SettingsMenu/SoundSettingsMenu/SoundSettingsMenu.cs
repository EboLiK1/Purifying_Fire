using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SoundSettingsMenu : ClosableMenu
{
    #region Êíîïêè
    [Header("Êíîïêè")]
    [SerializeField] private Button _music;
    [SerializeField] private Button _effects;
    #endregion

    public override void Awake()
    {
        base.Awake();

        _music.onClick.AddListener(() => { SetMusic(); });
        _effects.onClick.AddListener(() => { SetEffects(); });
    }

    private void Start()
    {
        int musicVolume = PlayerPrefs.GetInt("MusicVolume", 10);
        _music.GetComponent<ToggleMenuButton>()._selectedItemIndex = musicVolume;
        _music.GetComponent<ToggleMenuButton>().UpdateItemLabel();

        int effectsVolume = PlayerPrefs.GetInt("EffectsVolume", 10);
        _effects.GetComponent<ToggleMenuButton>()._selectedItemIndex = effectsVolume;
        _effects.GetComponent<ToggleMenuButton>().UpdateItemLabel();
    }

    public override void OnEnable()
    {
        base.OnEnable();

        _music.Select();
    }

    private void SetMusic()
    {
        var selector = _music.GetComponent<ToggleMenuButton>();
        int volumeIndex = selector.GetSelectedItemIndex();
        float volume = float.Parse(selector.Items[volumeIndex]) / 10;
        MusicManager.Instance.ChangeSound(volume);
        AudioManager.Instance.PlayPressButtonSound();
    }

    private void SetEffects()
    {
        var selector = _effects.GetComponent<ToggleMenuButton>();
        int volumeIndex = selector.GetSelectedItemIndex();
        float volume = float.Parse(selector.Items[volumeIndex]) / 10;
        AudioManager.Instance.ChangeEffectsVolume(volume);
        AudioManager.Instance.PlayPressButtonSound();
    }
}
