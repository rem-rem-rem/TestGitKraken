using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boooom : Interactable
{
    public float health = 50;
    //public float getData;
    public WeaponManager data;
    public HealtherBar healtherBar;

    private Animator animator;
    private NavMeshAgent navMeshAgent;

    public GameObject exp;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    protected override void Interact()
    {
        takeDamage(data.equippedWeapon.damage);
    }
    void OnTriggerStay(Collider other)
    {
        if (other.name == "Boom")
        {
            takeDamage(500);
        }

    }


    public void takeDamage(float damage)
    {
        health -= damage;
        healtherBar.SetHealth(health);
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject _exp = Instantiate(exp.gameObject, transform.position, transform.rotation);
        knowBack();
        Destroy(_exp, 1.5f);
        animator.SetBool("Die", true);
        navMeshAgent.speed = 1;
        Destroy(gameObject, 3);
    }

    void knowBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 8);

        foreach (Collider nearyby in colliders)
        {
            Rigidbody rigg = nearyby.GetComponent<Rigidbody>();
            if (rigg != null)
            {
                rigg.AddExplosionForce(800, transform.position, 8);
            }
        }
    }
}
