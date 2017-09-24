using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;
    public GameObject defenderPrefab;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if (defenderPrefab)
        {
            spriteRenderer.color = new Color(255f, 255f, 255f);
            selectedDefender = defenderPrefab;
        }
    }

    private void OnMouseUp()
    {
        // Done differently in video - see TowerSelector Buttons lecture 11:50 (ish)
        spriteRenderer.color = new Color(0f, 0f, 0f);
    }

}
