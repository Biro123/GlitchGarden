﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSpawner : MonoBehaviour {

    private Camera myCamera;
    private GameObject defenderParent;
    private StarDisplay starDisplay;

    // Use this for initialization
    void Start () {
        myCamera = FindObjectOfType<Camera>();
        starDisplay = FindObjectOfType<StarDisplay>();

        // Create a parent to collect all spawned projectiles under - if not already existing.
        defenderParent = GameObject.Find("Defenders");

        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        GameObject startPanel = GameObject.Find("StartPanel");
        if (startPanel) { return; } // check if paused (ie startpanel active)
        if (!Button.selectedDefender) { return; }
        
        int defenderCost = Button.selectedDefender.GetComponent<Defender>().startCost;
        Frog frog = Button.selectedDefender.GetComponent<Frog>();
        
        if (frog)
        {
            GameObject frogButton = GameObject.Find("FrogButton");
            SpriteRenderer frogSpriteRenderer = frogButton.GetComponent<SpriteRenderer>();
            if( frogSpriteRenderer.sprite == null)
            {
                return;
            } else
            {
                spawnDefender();
                frogSpriteRenderer.sprite = null;
            }
        }

        // NB enums are viewed as static so are accessed by the class not an instance.
        if (starDisplay.UseStars(defenderCost) == StarDisplay.status.SUCCESS)
        {
            spawnDefender();
        } 
    }

    private void spawnDefender()
    {
        Vector2 spawnPos = SnapToGrid(CalculateWorldPointOfMouse());
        GameObject defender = Instantiate(Button.selectedDefender, spawnPos, Quaternion.identity);
        defender.transform.SetParent(defenderParent.transform);
    }

    private Vector2 CalculateWorldPointOfMouse()
    {
        return myCamera.ScreenToWorldPoint(Input.mousePosition);               
    }

    private Vector2 SnapToGrid (Vector2 worldPos)
    {
        float newX = Mathf.Clamp(Mathf.RoundToInt(worldPos.x),1,9);
        float newY = Mathf.Clamp(Mathf.RoundToInt(worldPos.y),1,5);
        return new Vector2(newX, newY);
    }

}
