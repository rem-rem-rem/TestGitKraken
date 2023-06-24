using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFX_life : MonoBehaviour
{
    public float life = 1;
    void Awake()
    {
        Destroy(gameObject, life);//xoa dan sau life giay
    }
}
