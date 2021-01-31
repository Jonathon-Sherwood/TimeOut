using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCatch : MonoBehaviour
{
    public GameObject player;
    public GameObject returnPoint;
    public GameObject playgroundCover;
    public GameObject parkingLotCover;
    public GameObject parkingLotExit;
    public GameObject parkingLotEntrance;
    public GameObject playgroundExit;
    public GameObject playgroundEntrance;
    public GameObject catchImage;
    public GameObject hubCover;
    public Text caughtDialogue;

    [TextArea(3, 10)]
    public string[] dialogue;

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            caughtDialogue.text = dialogue[Random.Range(0, dialogue.Length)];
            player.transform.position = returnPoint.transform.position;
            playgroundCover.SetActive(false);
            parkingLotCover.SetActive(false);
            parkingLotEntrance.SetActive(false);
            parkingLotExit.SetActive(true);
            playgroundEntrance.SetActive(false);
            playgroundExit.SetActive(true);
            hubCover.SetActive(true);
            gameObject.SetActive(false);
            catchImage.SetActive(true);
        }
    }

}
