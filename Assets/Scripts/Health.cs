using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {

    public float health = 100f;
    public GameObject particle;
    public GameObject graveStonePrefab;
    private float damageModifier = 1;
    

    public void Start()
    {
        float difficulty = PlayerPrefsManager.getDifficulty();
        damageModifier = (difficulty * 0.2f) - 0.4f; 
    }

    public void TakeDamage(float damage)
    {
        float damageTaken = damage;

        if (gameObject.GetComponent<Defender>())
        {
            damageTaken = damage * (1 + damageModifier);
        } else
        {
            damageTaken = damage * (1 - damageModifier);
        }

        health -= damageTaken;

        if (health <= 0)
        {
            // TODO Optionally trigger an animation
            DestroyObject();
        }

    }

    // Created own Destroy method so it can be called from the Animator at end of death anim.
    public void DestroyObject()
    {        
        PuffSmoke();
        Destroy(gameObject);

        if (gameObject.GetComponent<Defender>()) {
            SpawnGraveStone();
        }
    }

    public void SpawnGraveStone() {
        if (gameObject.GetComponent<Gravestone>()) { return; }
        if (!graveStonePrefab) { return; }

        GameObject graveStone = Instantiate(graveStonePrefab, gameObject.transform.position, Quaternion.identity);
        graveStone.transform.SetParent(GameObject.Find("Defenders").transform);        
    }

    private void PuffSmoke()
    {
        // Create smoke at the Objects position
        if (particle)
        {
            GameObject smokePuff = Instantiate(particle, gameObject.transform.position, Quaternion.identity);
            Destroy(smokePuff, 1); // destroy it after 1 second
        }

    }

}
