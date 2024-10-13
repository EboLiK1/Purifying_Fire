using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DeletableCutscene : MonoBehaviour
{
    private PlayableDirector _cutscene;

    private void Awake()
    {
        _cutscene = GetComponent<PlayableDirector>();

        if (Game.IsFirstGame)
        {
            _cutscene.Play();
            Game.IsFirstGame = false;
        }

    }
}
