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
        if (Input.GetKeyDown(KeyCode.F5))
        {
            StopMusic();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            StartMusic();
        }
    }

    public void InitializeAudio()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        pad = audio[0];
        lead = audio[1];
        bass = audio[2];
        drums = audio[3];

        pad.volume = .2f;
        lead.volume = .2f;
        bass.volume = .2f;
        drums.volume = .2f;

        lead.mute = !lead.mute;
        bass.mute = !bass.mute;
        drums.mute = !drums.mute;
               
    }

    public void StopMusic()
    {
        if (MusicPlayingCheck())
        {
            Debug.Log("Stopping all music.");
            pad.Stop();
            lead.Stop();
            bass.Stop();
            drums.Stop();
        }
        else
        {
            Debug.Log("Cannot stop music. Music is not playing.");
        }
    }

    public void StartMusic()
    {
        if (!MusicPlayingCheck())
        {
            Debug.Log("Starting all music.");
            pad.Play();
            lead.Play();
            bass.Play();
            drums.Play();
        }
        else
        {
            Debug.Log("Cannot start music. Music is already playing.");
        }
    }

    public bool MusicPlayingCheck()
    {
        if ((pad.isPlaying == true) && (lead.isPlaying == true) && (bass.isPlaying == true) && drums.isPlaying == true)
        {
            return true;
        }
        else { return false; }
    }

    public static void ToggleMute(AudioSource audio)
    {
        audio.mute = !audio.mute;
        Debug.Log("Mute Toggled");
    }
}
