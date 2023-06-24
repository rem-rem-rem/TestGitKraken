using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    // Start is called before the first frame update
    //public NavMeshAgent enemy;
    //public Transform Player;
    private Player_Main player;
    private float myTime = 0.0f;
    private float nextFire = 0.0f;
    public float HP_LOSS = 5f;

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
        if(animator != null) animator.SetBool("IsRunning", true);
        //enemy.SetDestination(Player.position);
    }

    void OnTriggerStay(Collider other)
    {
        myTime += Time.deltaTime;
        // Kiểm tra xem vật thể va chạm có phải là vật thể bạn quan tâm hay không
        if (other.name == "Player" && myTime >= nextFire)
        {
            nextFire = myTime + HP_LOSS;
            player.TakeDamage(20);
            nextFire -= myTime;
            myTime = 0.0F;

            // Vật thể đã chạm vào vật thể bạn quan tâm
            // Thực hiện các hành động, xử lý, hay gọi các phương thức khác tùy theo yêu cầu của bạn
        }
    }
}
