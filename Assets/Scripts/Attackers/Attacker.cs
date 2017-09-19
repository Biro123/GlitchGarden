using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject currentTarget;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(name + "trigger enter");
    }

    public void SetCurrentSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from the Animator when in 'attack mode'
    public void StrikeCurrentTarget(float damage)
    {
        Debug.Log(name + "caused " + damage.ToString() + " damage");
    }

    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

}
