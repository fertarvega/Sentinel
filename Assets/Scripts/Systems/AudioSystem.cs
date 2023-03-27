using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSources;
    [SerializeField] private Slider volumeSlider;

    private void Start(){
        foreach(AudioSource source in _audioSources){
            source.volume = 0.5f;
        }

        volumeSlider.value = 0.5f;
    }

    private void Update(){
        foreach(AudioSource source in _audioSources){
            source.volume = volumeSlider.value;
        }
    }
}
