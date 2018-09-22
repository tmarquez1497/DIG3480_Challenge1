# DIG3480_Challenge1

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour { 


    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;


    private Rigidbody rb, Player;
    private int count, score, yellowPickups;


    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        yellowPickups = 0;
        SetAllText();
        winText.text = "";
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
       
       
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

      
        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);

            count = count + 1;
            score = score + 1; // I added this to start tracking score and count separate.
            yellowPickups = yellowPickups + 1;
            SetAllText();

            if (yellowPickups == 12)
            {
                transform.position = new Vector3(27.7f, 0.44f, -6.5f);
            }
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score - 1;
            SetAllText();
        }

        else if (other.gameObject.CompareTag("MoveWall"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetAllText();
        }
    }

    void SetAllText()
    {
        countText.text = "Count: " + count.ToString();
        scoreText.text = "Score: " + score.ToString();
        if ( yellowPickups == 24)
        {
            winText.text = "You won with a score of: " + score.ToString();
        }
        
    }

}

----------------------------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour



{
    private Vector3 pos1 = new Vector3(20.0f, 1.0f, 0f);
    private Vector3 pos2 = new Vector3(35.5f, 1.0f, 0f);
    public float speed = 1.0f;

   

    void Update()
    {
        transform.position = new Vector3(27.7f, 0.44f, -6.5f);

        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
}

