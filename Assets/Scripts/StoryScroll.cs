using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StoryScroll : MonoBehaviour {

    [SerializeField]
    private float speed = 2.8f;
    private float InputDelay = 2f;
    private float scrollDelay = 1.5f;
    private bool ready = false;
    private bool scroll = false;

    // Use this for initialization
    void Start () {
        StartCoroutine(WaitForInput());
        StartCoroutine(StartScroll());
	}
	
	// Update is called once per frame
	void Update () {


        if (ready == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ready = false;
                StartCoroutine(WaitForNextScene());
            }
        }

        if (scroll == true)
        {
            transform.Translate(Vector3.up * Time.deltaTime / speed);
        }
    }

    IEnumerator WaitForNextScene()
    {
        StoryAudio.SnoopSong.Stop();
        StoryAudio.RobotVoice.Stop();
        StoryAudio.Select.Play();
        scroll = false;
        Debug.Log("Waiting");
        yield return new WaitForSeconds(3f);
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("MenuPause");
    }

    IEnumerator WaitForInput()
    {
        ready = false;
        yield return new WaitForSeconds(InputDelay);
        Debug.Log("Ready for input.");
        ready = true;
    }

    IEnumerator StartScroll()
    {
        scroll = false;
        yield return new WaitForSeconds(scrollDelay);
        scroll = true;
    }
}
