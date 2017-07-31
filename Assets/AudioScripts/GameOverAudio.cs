using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverAudio : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GameObject musicController = GameObject.Find("MusicController");
        musicController.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("MenuPause_Restart");
            }
    }


}
