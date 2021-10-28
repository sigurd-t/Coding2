using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public KeyCode AudioTriggerButton;
    private AudioSource _audioSource;
    public AudioClip SoundToTrigger;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(AudioTriggerButton))
        {
            TriggerAudio();
        }
    }

    public void TriggerAudio()
    {
        _audioSource.PlayOneShot(SoundToTrigger);
    }
}
