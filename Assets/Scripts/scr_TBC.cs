using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scr_TBC : MonoBehaviour
{

    public float jump;

    //Player health
    public int maxHealth = 100;

    public int currentHealth;
    //public int enemyCurrentHealth;

    public scr_healthBar healthBar;
    public scr_enemyHealthBar enemyHealthBar;



    void Start()
    {
        currentHealth = maxHealth;
        //enemyCurrentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
       //enemyHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
       // enemyHealthBar.SetHealth(currentHealth);
    }


    public void PlayerAttack()
    {
        healthBar.SetHealth(10);
        enemyHealthBar.SetHealth(50);
    }

    public void PlayerBlock()
    {

    }

    public void PlayerHeal()
    {

    }
}
