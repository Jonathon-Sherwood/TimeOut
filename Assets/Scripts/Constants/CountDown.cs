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
    public GameObject playMusic;
    public bool playing = false;
    public AudioListener audioListener;
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
            Screams();
            playMusic.SetActive(false);
            timesUpImage.SetActive(true);
            player.GetComponent<PlayerMovement>().canMove = false;
            if(Input.anyKeyDown)
            {
                SceneManager.LoadScene(0);
            }
        }


    }

    void Screams()
    {
        if (!playing)
        {
            AudioListener.volume = .06f;
            AudioManager.instance.Play("CaughtScream");
            AudioManager.instance.Play("Scream0");
            AudioManager.instance.Play("Scream1");
            AudioManager.instance.Play("Scream2");
            AudioManager.instance.Play("Scream3");
            AudioManager.instance.Play("Scream4");
            AudioManager.instance.Play("Scream5");
            AudioManager.instance.Play("Scream6");
            AudioManager.instance.Play("Scream7");
            playing = true;
        }
    }

}
