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


    public void EnemyTakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        enemyHealthBar.SetHealth(enemyCurrentHealth);
    }


    public void ChooseEnemyMove()
    {
        int rand = Random.Range(1, 4);
        if(rand == 1)
        {
            EnemyBasicAttack();
        }
        if(rand == 2)
        {
            EnemyMagicAttack();
        }
        if(rand == 3)
        {
            EnemyHeal();
        }
    }

    public void EnemyBasicAttack()
    {
        Debug.Log("ENEMY Basic Attack");
        int damage = Random.Range(8, 13);
        GameObject.Find("PlayerTemp").GetComponent<scr_TBC>().TakeDamage(damage);
    }

    public void EnemyMagicAttack()
    {
        int accuracy = Random.Range(1, 6);
        if (accuracy < 4)
        {
            Debug.Log("ENEMY Magic Attack");
            int damage = Random.Range(13, 17);
            GameObject.Find("PlayerTemp").GetComponent<scr_TBC>().TakeDamage(damage);
        }
        else
        {
            Debug.Log("ENEMY Miss!");
        }

    }

    public void EnemyHeal()
    {
        Debug.Log("Enemy Heals");
        enemyCurrentHealth += 11;
        enemyHealthBar.SetHealth(enemyCurrentHealth);

    }
}
