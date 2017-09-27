using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    public int startCost = 30;

    private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {
        starDisplay = FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }

}
