﻿using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundSource : MonoBehaviour
{
    private void OnEnable()
    {
        if (Game.Instance == null)
        {
            return;
        }
        GetComponent<AudioSource>().enabled = Game.Instance.Settings.GetIsSoundEnabled();
        Game.Instance.Settings.OnSoundEnabled += OnSoundEnabled;
        Game.Instance.Settings.OnSoundDisabled += OnSoundDisabled;
    }

    private void OnDisable()
    {
        if (Game.Instance == null)
        {
            return;
        }
        Game.Instance.Settings.OnSoundEnabled -= OnSoundEnabled;
        Game.Instance.Settings.OnSoundDisabled -= OnSoundDisabled;
    }

    private void OnSoundDisabled()
    {
        GetComponent<AudioSource>().enabled = false;
    }

    private void OnSoundEnabled()
    {
        GetComponent<AudioSource>().enabled = true;
    }
}