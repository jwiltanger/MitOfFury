﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    /*Main camera follows player around scene
    public Transform player;
    //public Transform player; //to follow
    public float smoothing = 5f; //smooths so easier to see/ lag

    Vector3 offset;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.position; //vector from camera to player
    }

    //moves camera to follow player
    void FixedUpdate()
    {
        Vector3 targetPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing * Time.deltaTime);

    }*/

    public GameObject player;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }

}
