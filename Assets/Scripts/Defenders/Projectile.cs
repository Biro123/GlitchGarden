using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision");
        Attacker attacker = collision.GetComponent<Attacker>();
        Health health = collision.GetComponent<Health>();

        if (attacker && health)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);
        }
    }


    private void OnParticleCollision(GameObject collision)
    {
        Attacker attacker = collision.GetComponent<Attacker>();
        Health health = collision.GetComponent<Health>();

        if (attacker && health)
        {
            health.TakeDamage(damage);
        }

    }

}
