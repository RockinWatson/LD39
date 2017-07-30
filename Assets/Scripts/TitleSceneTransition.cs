using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleSceneTransition : MonoBehaviour {

    private bool ready;

    public GameObject ZMLogo;
    //public Transform ZMLogo_000;
    public Transform TitleCard;

    // Use this for initialization
    void Start () {
        Instantiate(ZMLogo, new Vector3(0, 0, 0), Quaternion.identity);
        StartCoroutine(WaitForInput());
        StartCoroutine(ShowTitleCard());

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

    IEnumerator ShowTitleCard()
    {
        //Destroy ZM logo and display title card
        //Resources.UnloadAsset(ZMLogo);
        yield return new WaitForSeconds(3.45f);
        Instantiate(TitleCard, new Vector3(0, 0.19f, 0), Quaternion.identity);
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
