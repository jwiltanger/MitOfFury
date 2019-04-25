using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health;
    public Text healthText;
    public AudioSource failureSound;
    public AudioSource hitSound;
    public GameObject player;
    public GameObject loseText;
    public GameObject loseSubText;
    // Start is called before the first frame update
    void Awake()
    {
        health = 4;
        hitSound = GetComponent<AudioSource>();
        failureSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
    }

    // Update is called once per frame
    public void damage()
    {
        health--;
        healthText.text = "HEALTH: " + health.ToString(); //display updated score
        if (health <= 0)
        {
            //player.gameObject.SetActive(false); //disable player
            failureSound.Play();
            loseText.SetActive(true);
            loseSubText.SetActive(true);
        }
        hitSound.Play(); //play sound
    }
}
