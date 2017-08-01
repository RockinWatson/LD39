using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public static AudioSource playerShoot;
    public static AudioSource enemyShoot;
    public static AudioSource pickup;
    public static AudioSource losePower;
    public static AudioSource explosion;
    public static AudioSource hitEnemy;

    private float startVolume = .2f;


    // Use this for initialization
        void Awake () {
            AudioSource[] audio = GetComponents<AudioSource>();

            playerShoot = audio[0];
            enemyShoot = audio[1];
            pickup = audio[2];
            losePower = audio[3];
            explosion = audio[4];
            hitEnemy = audio[5];

            StartingVolume();

            GameObject GameOverAudio = GameObject.Find("GameOverAudio");
            //GameOverAudio.SetActive(false);
            Destroy(GameOverAudio);
    }
    
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartingVolume()
    {
        playerShoot.volume = startVolume;
        enemyShoot.volume = startVolume;
        pickup.volume = startVolume;
        losePower.volume = startVolume;
        explosion.volume = .1f;
        hitEnemy.volume = startVolume;
    }
}
