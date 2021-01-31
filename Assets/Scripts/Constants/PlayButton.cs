using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public GameObject start, quit, credits, creditsScreen;
    private bool isCredits = false;

    //Loads the scene that has gameplay on button press.
    public void StartGame()
    {
        SceneManager.LoadScene("Hub");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isCredits)
        {
            Quit();
        } else if(Input.GetKeyDown(KeyCode.Escape) && isCredits)
        {
            Credits();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        isCredits = !isCredits;
        if (isCredits == true)
        {
            start.SetActive(false);
            credits.SetActive(false);
            quit.SetActive(false);
            creditsScreen.SetActive(true);
        } else
        {
            start.SetActive(true);
            credits.SetActive(true);
            quit.SetActive(true);
            creditsScreen.SetActive(false);
        }
    }
}
