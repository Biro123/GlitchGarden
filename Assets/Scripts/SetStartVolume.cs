using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStartVolume : MonoBehaviour {

    private MusicManager musicManager;

	// Use this for initialization
	void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        if (musicManager)
        {
            musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
        }
        else
        {
            Debug.LogWarning("MusicManager not found on start level");
        }
    }

}
