using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WhaleControl : MonoBehaviour
{

    public ParticleSystem hitParticles;
    public Text healthText;

    Health pHealth;
    GameObject player;
    Rigidbody rb;
    CapsuleCollider capsuleCollider;

    int health;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pHealth = player.GetComponent<Health>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy==false)
        {
            Instantiate(hitParticles);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) //check if coin
        {
            pHealth.damage();
        }
    }

}
