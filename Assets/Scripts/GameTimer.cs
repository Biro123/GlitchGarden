using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public int gameLengthSeconds = 60;
    private Slider slider;
    private LevelManager levelManager;
    private AudioSource audioSource;
    private GameObject youWin;
    private bool isEndOfLevel = false;

	// Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        levelManager = FindObjectOfType<LevelManager>();
        slider = GetComponent<Slider>();

        FindYouWin();
        youWin.SetActive(false);

        slider.value = 1;
    }

    private void FindYouWin()
    {
        youWin = GameObject.Find("YouWin");

        if (!youWin)
        {
            Debug.LogWarning("Win Text is missing");
        }
    }

    // Update is called once per frame
    void Update () {

        slider.value = 1-(Time.timeSinceLevelLoad / gameLengthSeconds);

        if (Time.timeSinceLevelLoad >= gameLengthSeconds && !isEndOfLevel)
        {
            LevelWon();
        }
	}

    private void LevelWon()
    {
        isEndOfLevel = true;
        audioSource.Play();
        youWin.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);        
    }

    private void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }

}
