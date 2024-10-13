using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private PlayableDirector _cutscene;
    [SerializeField] private float _finishCutsceneTime;

    [SerializeField] private string _nextScene;

    [SerializeField] private GameObject _skipMessage;

    private void Awake()
    {
        _cutscene.Play();
        _cutscene.stopped += OnTimelineFinished;
    }

    private void Update()
    {
        if (_skipMessage.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _cutscene.time = _finishCutsceneTime;
        }
    }

    void OnTimelineFinished(PlayableDirector director)
    {
        if (director.state == PlayState.Paused)
            SceneSwitcher.Instance.LoadScene(_nextScene);
    }
}
