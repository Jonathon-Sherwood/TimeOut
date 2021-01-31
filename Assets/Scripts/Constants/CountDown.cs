using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    public float timeLeft = 120;
    private float currentTimeLeft;
    public Image waitCountdownImageThing;
    public GameObject timesUpImage;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentTimeLeft = timeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLeft -= Time.deltaTime;
        waitCountdownImageThing.fillAmount = currentTimeLeft / timeLeft;
        if (currentTimeLeft < 0)
        {
            timesUpImage.SetActive(true);
            player.GetComponent<PlayerMovement>().canMove = false;
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
