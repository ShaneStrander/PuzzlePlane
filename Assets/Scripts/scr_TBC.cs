using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scr_TBC : MonoBehaviour
{
    //Player health
    public int maxHealth = 100;
    public int currentHealth;
    public scr_healthBar healthBar;

    int turn = 0;

    scr_TBCenemy enemy;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        enemy = GameObject.Find("Enemy").GetComponent<scr_TBCenemy>();
    }

    void Update()
    {
        if(currentHealth >= 0 && enemy.enemyCurrentHealth >= 0)
        {
            if(turn % 2 != 0)
            {
                enemy.ChooseEnemyMove();
                turn = turn + 1;
            }
        }
        else
        {
            if(currentHealth >= 0)
            {
                Debug.Log("PLAYER WINS");
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Minigame", 0);
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Progress", 2);
                SceneManager.LoadScene("Scene3");
            }
            else
            {
                Debug.Log("ENEMY WINS");
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Minigame", 0);
                SceneManager.LoadScene("Scene2");
            }
        }
        
    }

    // Takes damage and updates health bar
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    //Basic attack
    public void PlayerBasicAttack()
    {
        if (turn % 2 == 0)
        {
            Debug.Log("PLAYER Attacks");
            int damage = Random.Range(8, 13);
            enemy.EnemyTakeDamage(damage);
            turn = turn + 1;
        }
    }

    //Magic attack
    public void PlayerMagicAttack()
    {
        if (turn % 2 == 0)
        {
            int accuracy = Random.Range(1, 6);
            if(accuracy < 4)
            {
                Debug.Log("PLAYER Magic Attack");
                int damage = Random.Range(13, 17);
                enemy.EnemyTakeDamage(damage);
            }
            else
            {
                Debug.Log("PLAYER Miss!");
            }
            turn = turn + 1;
        }
    }

    //Heal
    public void PlayerHeal()
    {
        if (turn % 2 == 0)
        {
            Debug.Log("PLAYER Heals");
            currentHealth += 11;
            healthBar.SetHealth(currentHealth);
            turn = turn + 1;
        }
    }

}
