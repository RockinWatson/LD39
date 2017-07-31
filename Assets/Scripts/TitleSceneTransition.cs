using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleSceneTransition : MonoBehaviour {

    private bool ready;

    private bool _enterKey() { return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("enter"); }

    [SerializeField]
    private float InputDelay = 6f;

    public GameObject ZMLogo;
    public GameObject TitleCard;

    // Use this for initialization
    void Awake () {

        ZMLogo = Instantiate(Resources.Load("Title/ZMLogo")) as GameObject;
        StartCoroutine(WaitForInput());
        StartCoroutine(ShowTitleCard());
    }

    // Update is called once per frame
    void Update()
    {
        if (ready == true)
        {
            if (_enterKey())
            {
                ready = false;
                StartCoroutine(WaitForNextScene());
            }
        }
    }

    IEnumerator ShowTitleCard()
    {
        //Destroy ZM logo and display title card
        yield return new WaitForSeconds(3.45f);
        //Resources.UnloadAsset(ZMLogo);
        GameObject.Destroy(ZMLogo);
        TitleCard = Instantiate(Resources.Load("Title/TITLE")) as GameObject;
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
        yield return new WaitForSeconds(InputDelay);
        Debug.Log("Ready for input.");
        ready = true;
    }

}
