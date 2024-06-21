using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOnAppear : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}

