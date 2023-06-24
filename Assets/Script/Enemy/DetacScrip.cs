using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DetacScrip : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;

    public GameObject bullet;
    public Transform shootPoint;

    public float shootSpeed = 10f;
    public float timeToshoot = 1.3f;

    public NavMeshAgent meshAgent;
    float originalTime; 
    // Start is called before the first frame update
    void Start()
    {
        //meshAgent = GetComponent<NavMeshAgent>();
        originalTime = timeToshoot;
    }

    // Update is called once per frame
    void Update()
    {
        if(detected)
        {
            //meshAgent.speed = 3;
            enemy.LookAt(target.transform);
        }
    }

    private void FixedUpdate()
    {
        if (detected)
        {
            timeToshoot -= Time.deltaTime;
            if (timeToshoot <= 0)
            {
                ShootPlayer();
                timeToshoot = originalTime;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {   
        if (other.tag == "Player")
        {
            detected = true;
            target = other.gameObject;
            //Debug.Log(detected);
        }
    }

    private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rig = currentBullet.GetComponent<Rigidbody>();
        rig.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }
}
