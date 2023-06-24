using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : Playerinteract
{
    [SerializeField]
    protected Transform weaponSlot;
    [SerializeField]
    protected Transform weaponSlotGun;
    [SerializeField]
    protected Transform Spgun;

    protected GameObject currentWeapon;
    protected GameObject currentWeapon_Use;

    [SerializeField]
    public WeaponDataSO equippedWeapon;
    [SerializeField]
    public WeaponDataSO equippedWeapon_Use;
    public void EquipWeapon(WeaponDataSO weaponData)
    {

        if (currentWeapon != null)
        {
            Drop();
        }
        if (weaponData != null)
        {
            Pickup(weaponData);
        }

        // Debug.Log(weaponData);

    }

    private void Pickup(WeaponDataSO weaponData_P)
    {
        //Debug.Log("rem" + wp);
        Debug.Log(weaponData_P);
        currentWeapon = wp;
        if (wp == null)
        {
            Debug.Log("Can't grab");
        }

        else
        {
            equippedWeapon = weaponData_P;
            Debug.Log(weaponSlot.position);
            currentWeapon.transform.position = weaponSlot.position;
            currentWeapon.transform.parent = weaponSlot;
            //Debug.Log("Curre = " + currentWeapon.transform.parent.lossyScale);

            if (weaponData_P.type_get == "adc")
            {
                Debug.Log(weaponData_P.type_get);
                currentWeapon.transform.position = weaponSlotGun.position;
                currentWeapon.transform.parent = weaponSlotGun;
                equippedWeapon = weaponData_P;
            }
            currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
        }

        //for(int i = 0; i < inventory.slots.Length; i++)
        //{
        //    if(inventory.isFull[i] == false)
        //    {
        //        inventory.isFull[i] = true;
        //        break;
        //    }
        //}
    
    }

    public void Drop()
    {
        if (currentWeapon_Use == null)
        {
            equippedWeapon_Use = equippedWeapon;
            currentWeapon_Use = currentWeapon;
        }
        currentWeapon_Use.transform.position = Spgun.position;
        currentWeapon_Use.transform.parent = Spgun;
        currentWeapon_Use.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        currentWeapon_Use.GetComponent<Rigidbody>().isKinematic = true;

    }


}

