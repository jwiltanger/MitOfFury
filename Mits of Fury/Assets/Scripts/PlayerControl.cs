using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed = 6f;
    public float jumpHeight = 7f;
    public bool isGrounded;
    public Text instructions;
    public Text scoreText;
    public GameObject winText;
    public GameObject winSubText;
    public GameObject winLights;

    Vector3 movement;
    Rigidbody player;
    public AudioSource coinSound;
    public AudioSource winSound;


    private bool punching = false;
    private static int score;


    void Awake()
    {
        score = 0; // score starts at 0
        player = GetComponent<Rigidbody>();
        coinSound = GetComponent<AudioSource>();
        winSound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //gets rid of instructions
        if(Input.anyKeyDown)
        {
            instructions.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.X))
        {
            player.AddForce(Vector3.up * jumpHeight);
        }

        
        //check if player is punching and move player slightly 
        // kinda helps keeping the mit aligned
        if (!punching && Input.GetKeyDown(KeyCode.Space)) 
        {
            StartCoroutine(Punch(0.5f, 1.25f, transform.forward));
        }

        //normal player movement
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        movement.Set(h, v, 0f); 
        player.MovePosition(transform.position + movement);
        
        //rotate player to face whichever direction running toward
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 realDirection = Camera.main.transform.TransformDirection(movementDirection);

        if (realDirection.magnitude > 0.1f) //check for input
        {
            Quaternion newRotation = Quaternion.LookRotation(realDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10); //rotate
        }

        //rotation code: answers.unity.com/questions/178680/how-to-point-in-direction-of-arrow-keys.html
    }

    //called when player is punching
    IEnumerator Punch(float time, float distance, Vector3 direction)
    {
        punching = true;
        var timer = 0.0f;
        var orgPos = transform.position;
        direction.Normalize();
        Debug.Log("Above the loop");
        while (timer <= time)
        {
            Debug.Log("----");
            transform.position = orgPos;
            yield return null;
            timer += Time.deltaTime;
        }
        transform.position = orgPos;
        punching = false;
    }

    //Picks up coins and magic cube
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")) //check if coin
        {
            other.gameObject.SetActive(false); //disable coin
            coinSound.Play(); //play sound

            ScorePoint();

        }
        if (other.gameObject.CompareTag("Game")) //check if coin
        {
            other.gameObject.SetActive(false); //disable coin
            winSound.Play(); //play sound

            Wins();

        }
    }

    public void ScorePoint()
    {
        score++;
        score++; //increase score if potion collected
        scoreText.text = "SCORE: " + score.ToString(); //display updated score
    }

    public void Wins()
    {
        winLights.SetActive(true); //idk the sun rises or something
        enabled = false;
        winText.SetActive(true);
        winSubText.SetActive(true);
    }

}
