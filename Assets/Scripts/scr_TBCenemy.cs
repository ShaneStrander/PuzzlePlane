using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scr_TBCenemy : MonoBehaviour
{

    //Player health
    public int maxHealth = 100;

    public int enemyCurrentHealth;

    public scr_enemyHealthBar enemyHealthBar;

    public Text txt;

    int turnTemp;


    void Start()
    {
        enemyCurrentHealth = maxHealth;
        enemyHealthBar.SetMaxHealth(maxHealth);

        StartCoroutine(ChooseEnemyMove());
    }

    void Update()
    {
        turnTemp = GameObject.Find("TBCplayer").GetComponent<scr_TBC>().turn;
    }


    public void EnemyTakeDamage(int damage)
    {
        enemyCurrentHealth -= damage;
        enemyHealthBar.SetHealth(enemyCurrentHealth);
    }

    public IEnumerator ChooseEnemyMove()
    {
        while (true)
        {
            if (turnTemp % 2 != 0)
            {
                yield return new WaitForSeconds(3);

                int rand = Random.Range(1, 4);
                if (rand == 1)
                {
                    EnemyBasicAttack();
                }
                if (rand == 2)
                {
                    EnemyMagicAttack();
                }
                if (rand == 3)
                {
                    EnemyHeal();
                }

                yield return new WaitForSeconds(2);

                turnTemp = turnTemp + 1;
                GameObject.Find("TBCplayer").GetComponent<scr_TBC>().turn = turnTemp;
            }
            yield return null;
        }

    }

    public void EnemyBasicAttack()
    {
        int damage = Random.Range(8, 13);
        GameObject.Find("TBCplayer").GetComponent<scr_TBC>().TakeDamage(damage);
        txt.text = "The enemy's basic attack delt " + damage.ToString() + " damage";
    }

    public void EnemyMagicAttack()
    {
        int accuracy = Random.Range(1, 6);
        if (accuracy < 4)
        {
            int damage = Random.Range(13, 17);
            GameObject.Find("TBCplayer").GetComponent<scr_TBC>().TakeDamage(damage);
            txt.text = "The enemy's magic attack delt " + damage.ToString() + " damage";
        }
        else
        {
            txt.text = "The enemy misses!";
        }

    }

    public void EnemyHeal()
    {
        
        enemyCurrentHealth += 11;
        enemyHealthBar.SetHealth(enemyCurrentHealth);
        txt.text = "The enemy heals for 11 points!";

    }
}
