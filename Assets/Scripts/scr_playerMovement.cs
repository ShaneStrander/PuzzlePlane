using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_playerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveH, moveV;
    float direction = 1;
    [SerializeField] private float moveSpeed = 5.0f;

    private SpriteRenderer mySpriteRenderer;

    //For scaling up and down
    float scaleRate = 0.01f;
    float minScale = 0.75f;
    float maxScale = 0.8f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;

        //For changing which direction the player is facing
        if (moveH > 0)
        {
            direction = 1;
        }
        if (moveH < 0)
        {
            direction = -1;
        }

        // Calculating the scale rate
        if (transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveH, moveV);

        if(moveH != 0 || moveV != 0)
        {
            transform.localScale += new Vector3(.8f, .8f, .8f) * scaleRate;
        }

        if (direction == -1)
        {
            mySpriteRenderer.flipX = true;
        }
        else if ( direction == 1)
        {
            mySpriteRenderer.flipX = false;
        }
/*        else
        {
            transform.localScale = new Vector3(direction, 1, 1);
        }*/


    }
}






