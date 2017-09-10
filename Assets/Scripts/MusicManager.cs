using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicArray;

    private AudioSource backgroundMusic;

	// Use this for initialization
	void Start () {

        backgroundMusic = GetComponent<AudioSource>();
        AudioClip thisLevelMusic = levelMusicArray[LevelManager.GetBuildIndex()];

        if (thisLevelMusic) // If there is some music attached
        {
            Debug.Log("THisLevelMusic: " + thisLevelMusic.ToString());
            backgroundMusic.Stop();
            backgroundMusic.clip = thisLevelMusic;
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
