using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Four : MonoBehaviour
{
    public GameObject pic4; //image
    public GameObject text1;
    public GameObject text2;

    //Display image for three seconds then move to next image
    void Update()
    {
        pic4.SetActive(true); //image displays
        text1.SetActive(true);
        text2.SetActive(true);

        //activate following images 
        StartCoroutine(Next());
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(4); //wait 4 seconds before switching
        SceneManager.LoadScene("Five"); //switch scene
    }

}