using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Information : Interactable
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
        if (other.tag == "Boom")
        {
            Debug.Log("ádasdas");
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
        animator.SetBool("Die", true);
        navMeshAgent.speed = 1;
        Destroy(_exp, 2f);
        Destroy(gameObject, 2);
    }
}
