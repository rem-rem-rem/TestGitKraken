using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LP_Sword2 : Interactable 
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    //this function is where we will design our interaction using code
    protected override void Interact()
    {

        Debug.Log("Interact " + promptMessage);
        //Player.GetComponent<WeaponManager>().EquipWeapon(weaponDataSO);
        //Destroy(gameObject);
    }

}
