using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerSoundX : MonoBehaviour
{
    AudioSource ballonAudio;
    public AudioClip bounceSound;

    void Start()
    {
        ballonAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ballonAudio.PlayOneShot(bounceSound, 2f);
    }
}
