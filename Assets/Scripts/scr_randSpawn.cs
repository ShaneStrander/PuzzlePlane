using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_randSpawn : MonoBehaviour
{
    public Transform blueCoin;
    public Transform redCoin;

    public int numToSpawn;
    public Vector3 position;

    void Start()
    {
        position = new Vector3(Random.Range(-7.0f, 7F), Random.Range(-2.5F, 2.5F), -3);
        Instantiate(blueCoin, position, Quaternion.identity);

        position = new Vector3(Random.Range(-7.0f, 7F), Random.Range(-2.5F, 2.5F), -3);
        Instantiate(redCoin, position, Quaternion.identity);
    }

    //1 = blue and 2 = red
    public void Spawn(int color)
    {
        int spawned = 0;

        if (spawned < 2*numToSpawn - 1)
        {
            position = new Vector3(Random.Range(-5.0f, 5F), Random.Range(-2.0F, 2.0F), -3);
            if(color == 1)
            {
                Instantiate(blueCoin, position, Quaternion.identity);
            }
            else
            {
                Instantiate(redCoin, position, Quaternion.identity);
            }
            
            spawned++;
        }
    }

}
