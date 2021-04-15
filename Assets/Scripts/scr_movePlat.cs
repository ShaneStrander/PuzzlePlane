using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_movePlat: MonoBehaviour
{
    public float rightLimit = 3.8f;
    public float leftLimit = 0f;
    public float speed = 0.0f;

    private int direction = 1;
    private Vector3 movement;

    void Update()
    {
        
        if (transform.position.x > rightLimit)
        {
            direction = -1;
        }
        else if (transform.position.x < leftLimit)
        {
            direction = 1;
        }

        movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);
    }

}
