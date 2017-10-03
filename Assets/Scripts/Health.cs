using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {

    public float health = 100f;
    public GameObject particle;
    public GameObject graveStonePrefab;

    public void TakeDamage(float damage)
    {
        health -= damage;

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
