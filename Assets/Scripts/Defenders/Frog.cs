using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour {

    public static bool frogUsed = false;

    // Use this for initialization
    void Start () {
        
	}

    public void SetFrogUsed()
    {
        frogUsed = true;
    }

    public bool GetFrogUsed()
    {
        return frogUsed;
    }

    private void DestroyFrog()
    {
        Destroy(gameObject);
    }
}
