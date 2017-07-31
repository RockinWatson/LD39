using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuAudioController : MonoBehaviour {

    public AudioSource intro;
    public AudioSource select;

    private bool nextScene = false;

	// Use this for initialization
	void Awake () {
        AudioSource[] audio = GetComponents<AudioSource>();
        intro = audio[0];
        select = audio[1];

        intro.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && (nextScene == false))
        {
            StartCoroutine(WaitForNextScene());
            nextScene = true;
        }

    }

    IEnumerator WaitForNextScene()
    {
        intro.Stop();
        select.Play();
        Debug.Log("Waiting");
        yield return new WaitForSeconds(2f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("TestSceneJosh");
    }
}
