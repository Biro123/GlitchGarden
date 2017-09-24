using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabs;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject thisAttacker in attackerPrefabs)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }

	}

    bool isTimeToSpawn (GameObject attackerGameObject)
    {
        float rndNum = UnityEngine.Random.value;
        float seenEverySeconds = attackerGameObject.GetComponent<Attacker>().seenEverySeconds;
        float spawnChancePerSecond = 1 / seenEverySeconds;

        if (Time.deltaTime > seenEverySeconds)
        {
            Debug.LogWarning("Spawnrate capped by Framerate");
        }

        // divide by the number of lanes to give spawn chance overall
        if (rndNum <= spawnChancePerSecond * Time.deltaTime / 5) {
            return true;
        } else {
            return false;
        }
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject spawnedAttacker = Instantiate(myGameObject, this.transform.position, Quaternion.identity);
        spawnedAttacker.transform.parent = this.transform;
    }

}
