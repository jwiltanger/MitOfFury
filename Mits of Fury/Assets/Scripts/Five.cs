using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Five : MonoBehaviour
{
    public GameObject pic5; //image
    public GameObject text;
    public float fadeSpeed = 1.5f;

    //Display image for three seconds then move to next image
    void Update()
    {
        pic5.SetActive(true); //first image displays
        text.SetActive(true);

        //activate following images 
        StartCoroutine(Next());
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(4); //wait 4 seconds before switching
        SceneManager.LoadScene("Main"); //switch scene
    }

    /**void FadeToBlack() //maybe will add this later if time
    {
        GUITexture.enabled - true;
        GUITexture.color = Color.Lerp(GUITexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }**/

}