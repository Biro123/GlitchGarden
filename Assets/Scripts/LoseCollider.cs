using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        levelManager = FindObjectOfType<LevelManager>();
        if (!levelManager)
        {
            Debug.LogError("LevelManager not found");
        }
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.LoadLevel("03a_Lose");
    }

}
