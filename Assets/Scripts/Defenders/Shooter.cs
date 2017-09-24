using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, gun;
    private GameObject projectileParent;

    private void Start()
    {
        // Create a parent to collect all spawned projectiles under - if not already existing.
        projectileParent = GameObject.Find("Projectiles");
        
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = projectileParent.transform;

        float speed = newProjectile.GetComponent<Projectile>().speed;
        newProjectile.transform.Translate(Vector3.right * speed * Time.deltaTime);

    }


}
