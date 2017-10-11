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
        Debug.Log(this.name + " Trighits " + collision.name);
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
        Debug.Log(this.name + " Parthits " + collision.name);
        Attacker attacker = collision.GetComponent<Attacker>();
        Health health = collision.GetComponent<Health>();
        Projectile projectile = collision.GetComponent<Projectile>();
        ParticleSystem particleSystem = collision.GetComponent<ParticleSystem>();

        if (particleSystem) { return; } // don't destroy Frog's particle emitter.
        if (health || projectile)
        {
            Debug.Log("Destroying " + collision.name);
            Destroy(collision.gameObject);
        }

    }

}
