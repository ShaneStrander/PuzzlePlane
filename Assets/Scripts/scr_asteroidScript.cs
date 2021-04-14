using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scr_asteroidScript : MonoBehaviour
{
    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rb;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public float asteroidSize; //2 == Large 1 == Medium
    public GameObject asteroidMedium;
    public int points;
    public GameObject player;
    static Text scoreText;
    //Counter for score
    static int count = 0;



    // Start is called before the first frame update
    void Start()
    {
        //add random amount of torque and thrust to the asteroid
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);
        rb.AddForce(thrust);
        rb.AddTorque(torque);
        if (scoreText == null)
        {
            
            scoreText = GameObject.Find("ScoreText").GetComponentInChildren<Text>();
        }
        // player = GameObject.FindWithTag("Player").GetComponent<scr_spaceshipControls>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 newPos = transform.position;
        //screen wrapping
        if (transform.position.y > screenTop)
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



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);

            if(asteroidSize == 2)
            {
                // spawn two medium asteroids
                GameObject asteroid1 = Instantiate(asteroidMedium, transform.position, transform.rotation);
                GameObject asteroid2 = Instantiate(asteroidMedium, transform.position, transform.rotation);
                asteroid1.GetComponent<scr_asteroidScript>().asteroidSize = 1;
                asteroid2.GetComponent<scr_asteroidScript>().asteroidSize = 1;

                count ++;
                
            }else if (asteroidSize == 1)
            {
                count ++;
            }
            //player.ScorePoints(points);

            Destroy(gameObject);

           
            scoreText.text = "Score: " + count.ToString();

            if (count == 6)
            {
                SceneManager.LoadScene("Scene2");
            }

        }

    }

}
