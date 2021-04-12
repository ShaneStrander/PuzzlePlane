﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_spaceshipControls : MonoBehaviour
{
    public Rigidbody2D rb; 
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public float bulletForce;
    public float deathForce;

    public GameObject bullet;

    //private int score;
    public int lives;



    public Text livesText;

    [SerializeField]
    float accPower = 5f;
    [SerializeField]
    float steeringPower = 5f;
    float steeringAmount, speed, direction;

   



    // Start is called before the first frame update
    void Start()
    {
        
        
        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        //check input from the keyboard 
        //thrustInput = Input.GetAxis("Vertical");
        //turnInput = Input.GetAxis("Horizontal");

        //check for input from the fire key and make bullets
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce);
            Destroy(newBullet, 5.0f);
        }

        //rotate  the ship
        //transform.Rotate(Vector3.forward * turnInput * Time.deltaTime * turnThrust);

        Vector2 newPos = transform.position;
        //screen wrapping
        if(transform.position.y> screenTop)
        {
            newPos.y = screenBottom;
        }

        if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }
        
        if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }

        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }

        transform.position = newPos;

    }

    void FixedUpdate()
    {

        steeringAmount = -Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * accPower;
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

        rb.AddRelativeForce(Vector2.up * speed);

        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);

        //rb.AddRelativeForce(Vector2.up * thrustInput * thrust);
        //rb.AddTorque(-turnInput * thrust);

    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.relativeVelocity.magnitude > deathForce)
        {
            lives--;
            livesText.text = "Lives: " +  lives;
            if (lives <= 0)
            {
                SceneManager.LoadScene("Scene1");
            }
        }



      
    }

}