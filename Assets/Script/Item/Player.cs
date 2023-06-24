using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health;
    public int mana;

    public Text healthText;
    public Text manaText;

    void Start()
    {
        health=100;
        healthText.text="Health: "+health;
        mana=0;
        manaText.text="Mana: "+mana;
    }

    public void IncreaseHealth(int value){
        health+=value;
        healthText.text="Health: "+health;
    }

    public void IncreaseMana(int value){
        mana+=value;
        manaText.text="Mana: "+mana;
    }
}
