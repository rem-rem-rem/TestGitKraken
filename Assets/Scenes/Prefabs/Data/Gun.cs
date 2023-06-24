using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPosition;
    public GameObject bulletPrefab;
    public GameObject Gun_M41D;
    public float bulletSpeed = 200f;
    private float myTime = 0.0f;
    private float nextFire = 0.0f;
    public Transform equipPosition;

    void Update()
    {
        myTime += Time.deltaTime;
        //if(Input.GetKey(KeyCode.J)&& myTime>=nextFire)
        if (Gun_M41D.transform.parent == equipPosition)

            if (Input.GetButton("Fire1") && myTime >= nextFire)
            {
                Debug.Log("REMREMRMEMR");
                //nextFire = myTime + fireDelta;
                //var bullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
                //bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPosition.forward * bulletSpeed;
                //nextFire -= myTime;
                //myTime = 0.0F;
            }
    }
}