using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {

    public float movespeed;
    public Vector3 direction = Vector3.left;


    // Use this for initialization
    void Start () {
        transform.position = new Vector3(7.5f, Random.Range(-3, 3), 0);
        movespeed = Random.Range(1.5f, 3.5f);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(direction * movespeed * Time.deltaTime);
    }

}
