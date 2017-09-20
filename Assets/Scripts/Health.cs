using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour {

    public float health = 100f;

    public void TakeDamage(float damage)
    {
        Debug.Log(name + "Taking Damage: " + damage.ToString());

        health -= damage;

        if (health <= 0)
        {
            // Optionally trigger an animation
            Debug.Log(name + "Destroyed");
            DestroyObject();
        }

    }

    // Created own Destroy method so it can be called from the Animator at end of death anim.
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

}
