using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSources;

    private void Start(){
        foreach(AudioSource source in _audioSources){
            source.volume = 0.75f;
        }
    }
}
