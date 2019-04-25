using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //AudioSource.PlayClipAtPoint(sound, transform.position); //play witch laugh
            gameObject.SetActive(false); //remove potion from screen
            //GameManage.instance.ScorePoint(); //increase score in game manager
        }
    }
}
