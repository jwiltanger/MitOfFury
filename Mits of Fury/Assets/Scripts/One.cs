using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class One : MonoBehaviour
{
    public GameObject pic1; //image
    public GameObject text;

    //Display image for three seconds then move to next image
    void Update()
    {
        pic1.SetActive(true); //make sure all images active
        text.SetActive(true);

        //activate following images 
        StartCoroutine(Next());
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(4); //wait 4 seconds before switching
        SceneManager.LoadScene("Two"); //switch scene
    }

}
