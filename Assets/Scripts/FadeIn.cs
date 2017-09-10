using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public float fadeInTime = 2.0f;

	// Use this for initialization
	void Start () {
        GetComponent<Image>().CrossFadeColor(new Color(0, 0, 0, 0), fadeInTime, false, true);
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > fadeInTime)
        {
            gameObject.SetActive(false);
        }    
	}
}
