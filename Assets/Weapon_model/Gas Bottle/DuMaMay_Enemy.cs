using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DuMaMay_Enemy : MonoBehaviour
{
    private Player_Main player;
    public float expForce = 0.0f;
    public float radius  = 0.0f;

    public GameObject exp;
    public Animator animator;
    NavMeshAgent agent;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").GetComponent<Player_Main>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
        if (animator != null) animator.SetBool("IsRunning", true);
        //enemy.SetDestination(Player.position);
    }
    void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log(other.name);
            GameObject _exp = Instantiate(exp.gameObject, transform.position, transform.rotation);
            player.TakeDamage(50);
            Destroy(_exp, 1.5f);
            knowBack();
            Destroy(gameObject);
        }

    }

    void knowBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearyby in colliders)
        {
            Rigidbody rigg = nearyby.GetComponent<Rigidbody>();
            if(rigg != null)
            {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }
}