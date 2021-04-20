using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class scr_TBC : MonoBehaviour
{
    //Player health
    public int maxHealth = 100;
    public int currentHealth;
    public scr_healthBar healthBar;

    public int turn = 0;

    //For Updating PlayByPlay
    public Text txt;

    scr_TBCenemy enemy;
    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        enemy = GameObject.Find("Enemy").GetComponent<scr_TBCenemy>();
        txt.text = "Make a move!";
    }

    void Update()
    {
        if(currentHealth >= 0 && enemy.enemyCurrentHealth >= 0)
        {
            if(turn % 2 != 0)
            {
                enemy.ChooseEnemyMove();
            }
        }
        else
        {
            if(currentHealth >= 0)
            {
                txt.text = "You Win!";
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Minigame", 0);
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Progress", 1);
                SceneManager.LoadScene("Scene3");
            }
            else
            {
                txt.text = "You Lose!";
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
            int damage = Random.Range(8, 13);
            enemy.EnemyTakeDamage(damage);
            turn = turn + 1;
            txt.text = "Your basic attack delt " + damage.ToString() + " damage!";
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
                int damage = Random.Range(13, 17);
                enemy.EnemyTakeDamage(damage);
                txt.text = "Your magic attack delt " + damage.ToString() + " damage!";
            }
            else
            {
                txt.text = "Your magic attack missed!";
            }
            turn = turn + 1;
        }
    }

    //Heal
    public void PlayerHeal()
    {
        if (turn % 2 == 0)
        {
            currentHealth += 11;
            healthBar.SetHealth(currentHealth);
            turn = turn + 1;
            txt.text = "You healed yourself for 11 points!";
        }
    }

}
