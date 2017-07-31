﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverAudio : MonoBehaviour {

    public AudioSource Intro;
    public AudioSource Select;

    public bool selectUsed = false;

    void Awake ()
    {
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () {

        AudioSource audio = GetComponent<AudioSource>();
        Intro = audio;
        Intro.Play();

        GameObject musicController = GameObject.Find("MusicController");
        musicController.SetActive(false);
        Destroy(musicController);


    }
	
	// Update is called once per frame
	void Update () {



        if (Input.GetKeyDown(KeyCode.Return))

        {

            Scene menu = SceneManager.GetActiveScene();
            string sceneName = menu.name;

            if (sceneName == "MenuPause_Restart")
            {
                Intro.Stop();
            }

            if (selectUsed == false)
            {
                Select.Play();
                selectUsed = true;
                SceneManager.LoadScene("MenuPause_Restart");
            }

        }
                             

    }


}
