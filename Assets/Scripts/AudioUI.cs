using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUI : MonoBehaviour
{
    private AudioSource uiAudioSource;

    private void Awake(){
        uiAudioSource = GetComponent<AudioSource>();
    }

    public void PlayUiButtonAudioSource(){
        uiAudioSource.Play();
    }
}
