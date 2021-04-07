using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_carSteering : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float accPower = 5f;
    [SerializeField]
    float steeringPower = 5f;
    float steeringAmount, speed, direction;

    //Counter for Coin Collecting
    int count = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        steeringAmount = - Input.GetAxis("Horizontal");
        speed = Input.GetAxis("Vertical") * accPower;
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

        rb.AddRelativeForce(Vector2.up * speed);

        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlueCoin")
        {
            Destroy(collision.gameObject);
            count = count + 1;
        }

        if (collision.CompareTag("FinishLine") && count == 2)
        {
            SceneManager.LoadScene("Scene5");
        }
    }
}
