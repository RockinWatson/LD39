using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StoryAudio : MonoBehaviour {

    public static AudioSource SnoopSong;
    public static AudioSource RobotVoice;
    public static AudioSource Select;

    private bool changeScene = false;
    //public static GameObject audioController;

    // Use this for initialization
    void Awake () {
        AudioSource[] audio = GetComponents<AudioSource>();
        SnoopSong = audio[0];
        RobotVoice = audio[1];
        Select = audio[2];
        
        Select.volume = .3f;
        RobotVoice.volume = .5f;
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckScene();
        }

    }

    public void CheckScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;
        Debug.Log("Active scene is '" + scene.name + "'.");


        if ((sceneName == "MenuPause") && (changeScene == false))
        {
            StartCoroutine(WaitForNextScene());
            changeScene = true;
        }
    }

    IEnumerator WaitForNextScene()
    {
        StoryAudio.SnoopSong.Stop();
        StoryAudio.Select.Play();
        Debug.Log("Waiting");
        yield return new WaitForSeconds(2f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("TestSceneJosh");
        GameObject audioController = GameObject.Find("AudioController");
        audioController.SetActive(false);
    }
}
