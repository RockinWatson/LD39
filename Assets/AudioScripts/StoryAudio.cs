using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryAudio : MonoBehaviour {

    public static AudioSource SnoopSong;
    public static AudioSource RobotVoice;

    // Use this for initialization
    void Awake () {
        AudioSource[] audio = GetComponents<AudioSource>();
        SnoopSong = audio[0];
        RobotVoice = audio[1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
