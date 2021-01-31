using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public float timeLeft = 120;
    private float currentTimeLeft;
    public Image waitCountdownImageThing;
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
            print("Game Over");
        }
    }
}
