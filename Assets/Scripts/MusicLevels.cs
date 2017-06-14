using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicLevels : MonoBehaviour
{

    static bool AudioBegin = false;
    private AudioSource audio;
    void Start()
    {
        if (!AudioBegin)
        {
            audio.Play();
            DontDestroyOnLoad(gameObject);
            AudioBegin = true;
        }
    }
}