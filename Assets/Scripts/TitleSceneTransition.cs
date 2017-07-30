using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleSceneTransition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            TitleAudio.StopAudio();
            StartCoroutine(wait());
        }
       }


    IEnumerator wait()
    {

        TitleAudio.Select.Play();
        Debug.Log("Waiting");
        yield return new WaitForSeconds(3f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("StoryScene");
    }


}
