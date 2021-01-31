using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public GameObject[] kids;
    public float timeLeft = 1;
    private float currentTimeLeft;

    private void Start()
    {
        currentTimeLeft = .1f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeLeft -= Time.deltaTime;
        if (currentTimeLeft < 0)
        {
            kids[Random.Range(0, kids.Length)].GetComponent<Animator>().Play("Jump");
            print("jump");
            currentTimeLeft = Random.Range(0,timeLeft);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
