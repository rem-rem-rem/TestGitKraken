using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Data/WeaponData")]

public class WeaponDataSO : ScriptableObject
{
    public int damage;
    public string weaponName;
    public string type_get;
    public float range;
    public Sprite Icon;
    public float timeDelay;
}
