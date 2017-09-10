using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicArray;

    private AudioSource backgroundMusic = null;
    private AudioClip currentMusic = null;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        SceneManager.sceneLoaded += loadScene;
        backgroundMusic = GetComponent<AudioSource>();        
	}
	
    void loadScene(Scene scene, LoadSceneMode mode)
    {
        AudioClip thisLevelMusic = levelMusicArray[scene.buildIndex];

        // If there is some music attached and it isn't already playing
        if (thisLevelMusic && currentMusic != levelMusicArray[scene.buildIndex]) 
        {
            Debug.Log("THisLevelMusic: " + thisLevelMusic.ToString());
            backgroundMusic.Stop();
            backgroundMusic.clip = thisLevelMusic;
            backgroundMusic.loop = true;
            backgroundMusic.Play();
            currentMusic = levelMusicArray[scene.buildIndex];
        }
    }
}
