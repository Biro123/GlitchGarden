using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;
    public GameObject defenderPrefab;
    private Button[] buttonArray;
    private Text costText;

    // Use this for initialization
    void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();

        costText = GetComponentInChildren<Text>();

        if (!costText)
        {
            Debug.LogWarning("costText not found for " + name);
        }

        costText.text = defenderPrefab.GetComponent<Defender>().startCost.ToString();

        selectedDefender = null;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        // Set all buttons to black
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        // set this one to white
        if (defenderPrefab)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            selectedDefender = defenderPrefab;
        }
    }

}
