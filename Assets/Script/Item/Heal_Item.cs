//T chỉnh nè thg lol
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal_Item : MonoBehaviour
{
    private Player_Main player_Main;
    private UseItem1 Useitem1;

    private Image slot1;
    private Image slot2;
    private Image slot3;


    private void Start()
    {
        Useitem1 = GameObject.Find("Player").GetComponent<UseItem1>();
        player_Main = GameObject.Find("Player").GetComponent<Player_Main>();

        slot1 = GameObject.Find("potions_1").GetComponent<Image>();
        slot2 = GameObject.Find("potions_2").GetComponent<Image>();
        slot3 = GameObject.Find("potions_3").GetComponent<Image>();
    }
    void OnTriggerEnter(Collider other)
    {
        // Kiểm tra xem vật thể va chạm có phải là vật thể bạn quan tâm hay không
        if (other.name == "Player")
        {
            Useitem1.HpSlot += 1;
            switch (Useitem1.HpSlot)
            {
                case 1:
                    slot1.color = new Color32(121, 121, 126, 100);
                    break;
                case 2:
                    slot2.color = new Color32(121, 121, 126, 100);
                    break;
                case 3:
                    slot3.color = new Color32(121, 121, 126, 100);
                    break;
            }
            Destroy(gameObject);
        }

    }
}
