using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    public AudioClip[] clips = new AudioClip[2];

    public void Start() {
        GetComponent<AudioSource>().clip = clips[Random.Range(0, clips.Length)];
    }
}
