using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scr_TBCenemy : MonoBehaviour
{

    //Player health
    public int maxHealth = 100;

    public int enemyCurrentHealth;

    public scr_enemyHealthBar enemyHealthBar;



    void Start()
    {
        enemyCurrentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnemyTakeDamage(5);
        }
    }

    void EnemyTakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        enemyHealthBar.SetHealth(enemyCurrentHealth);
    }


    public void EnemyAttack()
    {

    }

    public void EnemyBlock()
    {

    }

    public void EnemyHeal()
    {

    }
}
