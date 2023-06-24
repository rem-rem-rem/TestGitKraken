using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DuMaMay : MonoBehaviour
{

    public float expForce = 0.0f;
    public float radius = 0.0f;

    public GameObject exp;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "AI")
        {
            GameObject _exp = Instantiate(exp.gameObject, transform.position, transform.rotation);
            Destroy(_exp, 1.5f);
            knowBack();
            Destroy(gameObject, 2);
        }

    }

    void knowBack()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearyby in colliders)
        {
            Rigidbody rigg = nearyby.GetComponent<Rigidbody>();
            if (rigg != null)
            {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
        }
    }
}