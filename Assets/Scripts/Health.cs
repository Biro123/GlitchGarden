using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {

    public float health = 100f;

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
        Destroy(gameObject);
    }

}
