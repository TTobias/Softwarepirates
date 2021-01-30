using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    public AudioClip[] clips = new AudioClip[2];

    public void Start() {
        GetComponent<AudioSource>().clip = clips[(int)Random.Range(0f, clips.Length - 0.0001f)];
    }
}
