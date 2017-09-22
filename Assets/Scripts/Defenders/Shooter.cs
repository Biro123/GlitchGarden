using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public GameObject projectile, projectileParent, gun;

    private void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = projectileParent.transform;

        float speed = newProjectile.GetComponent<Projectile>().speed;
        newProjectile.transform.Translate(Vector3.right * speed * Time.deltaTime);

    }


}
