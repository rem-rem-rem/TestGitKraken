using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal_place : MonoBehaviour
{
    public Slider slider;
    public Image fill;
    public Gradient gradient;
    private Player_Main player_Main;
    void Start()
    {
        player_Main = GameObject.Find("Player").GetComponent<Player_Main>();
    }
    void OnTriggerStay(Collider other)
    {
        // Kiểm tra xem vật thể va chạm có phải là vật thể bạn quan tâm hay không
        if (other.name == "Player")
        {
            fill.color = gradient.Evaluate(slider.normalizedValue);
            player_Main.currentHealth += 0.01f;
            slider.value = player_Main.currentHealth;
            if (player_Main.currentHealth > 100)
            {
                player_Main.currentHealth = 100;
            }
            // Vật thể đã chạm vào vật thể bạn quan tâm
            // Thực hiện các hành động, xử lý, hay gọi các phương thức khác tùy theo yêu cầu của bạn
        }
    }
}
