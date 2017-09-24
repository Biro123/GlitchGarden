using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderSpawner : MonoBehaviour {

    private Camera myCamera;
    GameObject defenderParent;

    // Use this for initialization
    void Start () {
        myCamera = FindObjectOfType<Camera>();

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
        Vector2 spawnPos = SnapToGrid( CalculateWorldPointOfMouse() );
        GameObject defender = Instantiate(Button.selectedDefender, spawnPos, Quaternion.identity);
        defender.transform.SetParent(defenderParent.transform);
    }

    Vector2 CalculateWorldPointOfMouse()
    {
        return myCamera.ScreenToWorldPoint(Input.mousePosition);
               
    }

    Vector2 SnapToGrid (Vector2 worldPos)
    {
        float newX = Mathf.RoundToInt(worldPos.x);
        float newY = Mathf.RoundToInt(worldPos.y);

        return new Vector2(newX, newY);
    }

}
