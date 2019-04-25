using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Two : MonoBehaviour
{
    public GameObject pic2; //images
    public GameObject text;

    //Display image for three seconds then move to next image
    void Update()
    {
        pic2.SetActive(true); //make sure everything is active
        text.SetActive(true);

        //activate following images 
        StartCoroutine(Next());
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(4); //wait 4 seconds before switching
        SceneManager.LoadScene("Three"); //switch scene
    }

}