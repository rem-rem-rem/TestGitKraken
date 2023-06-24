using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField]
    private WeaponDataSO weaponData;

    private void OnTriggerEnter(Collider other)
    {
    Debug.Log("Rem");
        WeaponManager weaponManager = other.GetComponent<WeaponManager>();
        if (weaponManager != null)
            weaponManager.EquipWeapon(weaponData);
        Destroy(gameObject);
    }

}


