using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text text;
    private int starCount = 125;
    public enum status { SUCCESS, FAILURE };

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "Stars: " + starCount.ToString();
    }
	
    public void AddStars(int amount ) {
        if (amount > 0)
        {
            starCount += amount;
            text.text = "Stars: " + starCount.ToString();
        }
    }

    public status UseStars(int amount)
    {
        if (starCount >= amount)
        {
            starCount -= amount;
            text.text = "Stars: " + starCount.ToString();
            return status.SUCCESS;
        }
        return status.FAILURE;
    }

}
