using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleSceneTransition : MonoBehaviour {

    private bool ready;

	// Use this for initialization
	void Start () {
        StartCoroutine(WaitForInput());
	}

    // Update is called once per frame
    void Update()
    {

        if (ready == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ready = false;
                StartCoroutine(WaitForNextScene());
            }
        }
    }


    IEnumerator WaitForNextScene()
    {
        TitleAudio.StopAudio();
        TitleAudio.Select.Play();
        Debug.Log("Waiting");
        yield return new WaitForSeconds(3f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("StoryScene");
    }

    IEnumerator WaitForInput()
    {
        ready = false;
        yield return new WaitForSeconds(8f);
        Debug.Log("Ready for input.");
        ready = true;
    }

}
