using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRelease : MonoBehaviour
{
    public float timeLeft = 10;
    private float currentTimeLeft;
    public GameObject player;
    public Image waitCountdownImageThing;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLeft -= Time.deltaTime;
        waitCountdownImageThing.fillAmount = currentTimeLeft / timeLeft;
        if (currentTimeLeft < 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<PlayerMovement>().canMove = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnEnable()
    {
        currentTimeLeft = timeLeft;
    }
}
