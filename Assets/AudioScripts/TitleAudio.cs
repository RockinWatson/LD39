using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudio : MonoBehaviour {

    public static AudioSource Title;
    public static AudioSource Select;
    public static AudioSource AutoTune;

    // Use this for initialization
    void Awake ()
    {
        AudioSource[] audio = GetComponents<AudioSource>();
        Title = audio[0];
        Select = audio[1];
        AutoTune = audio[2];

        InitializeAudio();
    }
	
	// Update is called once per frame
	void Update () {

	
	}

    public static void InitializeAudio()
    {
        if (!Title.isPlaying)
        {
            //Title.Play();
            Title.PlayDelayed(2);
            AutoTune.PlayDelayed(5.45f);
        }
        else
        {
            Debug.Log("Title music is already playing.");
        }
    }

    //public static void PlaySelect()
    //{
    //    Select.Play();
    //}

    public static void StopAudio()
    {
        if (Title.isPlaying)
        {
            Title.Stop();
        }
        else
        {
            Debug.Log("Title music is not playing.");
        }
    }

}
