using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;
    
    private void Start()
    {
        animator = GetComponent<Animator>();

        // Create a parent to collect all spawned projectiles under - if not already existing.
        projectileParent = GameObject.Find("Projectiles");
        
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();

    }

    private void Update()
    {
        if ( IsAttackerInLane() )
        {
            animator.SetBool("isAttacking", true);
        }    
        else
        {
            animator.SetBool("isAttacking", false);
        }

    }

    private bool IsAttackerInLane()
    {
        Attacker[] attackerArray = myLaneSpawner.GetComponentsInChildren<Attacker>();

        foreach (Attacker currAttacker in attackerArray)
        {
            if (currAttacker.gameObject.transform.position.x > this.transform.position.x)
            {
                return true;
            }
        }
        return false;

    }

    // Look through all spawners and set myLaneSpawner
    private void SetMyLaneSpawner()
    {
        float thisPos = this.gameObject.transform.position.y;
        Spawner[] spawnerArray = FindObjectsOfType<Spawner>();

        foreach (Spawner currSpawner in spawnerArray)
        {
            if (thisPos == currSpawner.transform.position.y)
            {
                myLaneSpawner = currSpawner;
                return;
            }
        }
        
        // Spwaner not found (see 'return' above)
        Debug.LogError("Spawner not found in lane " + thisPos.ToString());
        myLaneSpawner = null;
    }

    // Called from the animations
    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = projectileParent.transform;

        float speed = newProjectile.GetComponent<Projectile>().speed;
        newProjectile.transform.Translate(Vector3.right * speed * Time.deltaTime);

    }


}
