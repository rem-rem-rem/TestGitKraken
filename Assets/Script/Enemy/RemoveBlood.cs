using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBlood : MonoBehaviour
{
    public float life = 1;
    private Player_Main player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player_Main>();
    }
    void Awake()
    {
        Destroy(gameObject, life);//xoa dan sau life giay
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player.TakeDamage(20);
        }  
    }
}
