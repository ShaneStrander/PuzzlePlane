using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_raceEnemy : MonoBehaviour
{
    private Vector3 target;

    int enemyCount = 0;

    scr_randSpawn spawn;


    void Start()
    {
        spawn = GameObject.Find("Map").GetComponent<scr_randSpawn>();
    }

    void Update()
    {
        if (enemyCount < spawn.numToSpawn)
        {
            target = GameObject.Find("RedCoin(Clone)").transform.position;
        }
        else
        {
            target = GameObject.Find("Finish_Line").transform.position;
        }
        Move(target);
        
    }

    void Move(Vector3 tar)
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, 1.5f * Time.deltaTime);

        //Roating the car
        float rotationSpeed = 10f;
        float offset = -90f;
        Vector3 direction = target - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle + offset, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedCoin")
        {
            Destroy(collision.gameObject);
            enemyCount = enemyCount + 1;
            if (enemyCount < spawn.numToSpawn)
            {
                spawn.Spawn(2);
            }
        }

        if (collision.CompareTag("FinishLine") && enemyCount == spawn.numToSpawn)
        {
            //Debug.Log("You Lose");
            SceneManager.LoadScene("Scene4");
        }

    }
}
