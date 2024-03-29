﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get { return _instance; }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        if (!_instance)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();

    }

    public void PlaySound(AudioClip clip)
    {
        // Sound player here from any actor that needs to play sound 
        // in case we need to destroy said GameObjects.

        if (!PersistentManager.Instance)
        {
            Debug.LogWarning("Persistent Manager Needed");
            return;
        }

        if (PersistentManager.Instance.GetPlaySound())
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

    }

}
