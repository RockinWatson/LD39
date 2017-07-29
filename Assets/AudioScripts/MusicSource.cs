using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSource : MonoBehaviour
{

    public AudioSource pad;
    public AudioSource lead;
    public AudioSource bass;
    public AudioSource drums;

    // Use this for initialization
    void Awake ()
    {
        InitializeAudio();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            ToggleMute(pad);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ToggleMute(lead);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            ToggleMute(bass);
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            ToggleMute(drums);
        }
    }

    public void InitializeAudio()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        pad = audio[0];
        lead = audio[1];
        bass = audio[2];
        drums = audio[3];

        pad.volume = .5f;
        lead.volume = .5f;
        bass.volume = .5f;
        drums.volume = .5f;

        lead.mute = !lead.mute;
        bass.mute = !bass.mute;
        drums.mute = !drums.mute;
               
    }

    public static void ToggleMute(AudioSource audio)
    {
        audio.mute = !audio.mute;
        Debug.Log("Mute Toggled");
    }
}
