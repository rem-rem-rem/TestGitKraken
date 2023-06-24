using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Main : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    protected float GetHp;
    private Image HP_low;

    public Transform PlayerTransform;

    public HealtherBar healtherBar;
    // Start is called before the first frame update
    void Start()
    {
        HP_low = GameObject.Find("LowHP").GetComponent<Image>();
        currentHealth = maxHealth;
        healtherBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(20);
        //}

        if(currentHealth <= 20f)
        {
            HP_low.color = new Color32(255, 255, 255, 255);
        }

        else
        {
            HP_low.color = new Color32(255, 255, 255, 0);

        }

        if (currentHealth <= 0)
        {
            HP_low.color = new Color32(255, 255, 255, 0);
            PlayerTransform.position = new Vector3(-25.3f, 2.56f, -12.5f);
            currentHealth = 100;
            healtherBar.SetHealth(currentHealth);
        }

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healtherBar.SetHealth(currentHealth);
    }


}
