// System
using System;
using System.Collections;
using System.Collections.Generic;

// Unity
using UnityEngine;
using UnityEngine.UI;

// Project
// Alias

public class BGMSource : MonoBehaviour
{
    [Header("BGM AudioClip")]
    public AudioClip clip = null;

    [Header("Volume Settings")]
    [Range(0.0f, 1.0f)] public float startVolume = 0.0f;
    [Range(0.0f, 1.0f)] public float targetVolume = 1.0f;
    [Range(0.0f, 5.0f)] public float fadeDuration = 1.0f;

    private void Awake()
    {
        bool isMuted = PlayerPrefs.GetInt("BGMMuted", 1) == 0 ? true : false;
        AudioManager.GetOrCreate().SetMuted(isMuted);
    }

    private void Start()
    {
        if (clip)
        {
            AudioManager manager = AudioManager.GetOrCreate();
            manager.SetBGMClip(clip);
            manager.SetBGMVolume(startVolume);
            manager.PlayBGM();

            AudioHelper.FadeBGM(targetVolume: targetVolume, duration: fadeDuration);
        }
    }

    public void ChangeClip(AudioClip _clip)
    {
        AudioManager manager = AudioManager.GetOrCreate();
        manager.SetBGMClip(_clip);
        //manager.SetBGMVolume(startVolume);
        manager.PlayBGM();

        //AudioHelper.FadeBGM(targetVolume: targetVolume, duration: fadeDuration);
    }
}
