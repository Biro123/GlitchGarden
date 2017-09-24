using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject currentTarget;
    private Health currentTargetHealth;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (!currentTarget)
        {
            anim.SetBool("isAttacking", false);
        }

        Debug.Log("selected defender: " + Button.selectedDefender.ToString());

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
        if (currentTargetHealth)
        {
            currentTargetHealth.TakeDamage(damage);
        }
        else
        {
            Debug.LogWarning ("Target Not Found by: " + name);
        }
    }

    // On start of attack, detemrine what we are attacking
    public void Attack(GameObject obj)
    {
        currentTarget = obj;
        currentTargetHealth = obj.GetComponent<Health>();
    }

}
