using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseItem1 : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Gradient gradient;
    private Player_Main player_Main;
    private PlayerInput inputManager;
    private Image slot1;
    private Image slot2;
    private Image slot3;

    public int HpSlot;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<PlayerInput>();
        player_Main = GameObject.Find("Player").GetComponent<Player_Main>();
        slot1 = GameObject.Find("potions_1").GetComponent<Image>();
        slot2 = GameObject.Find("potions_2").GetComponent<Image>();
        slot3 = GameObject.Find("potions_3").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Use();
    }

    public void Use()
    {
        if (inputManager.onFoot.UseItem.triggered && HpSlot > 0)
        {
            switch (HpSlot)
            {
                case 1:
                    slot1.color = new Color32(0, 0, 0, 0);
                    break;
                case 2:
                    slot2.color = new Color32(0, 0, 0, 0);
                    break;
                case 3:
                    slot3.color = new Color32(0, 0, 0, 0);
                    break;

            }
            fill.color = gradient.Evaluate(slider.normalizedValue);
            player_Main.currentHealth += 20;
            Debug.Log("player_Main.currentHealth " + player_Main.currentHealth);
            slider.value = player_Main.currentHealth;
            HpSlot -= 1;
            if(player_Main.currentHealth > 100)
            {
                player_Main.currentHealth = 100;
            }
        }
    }
}
