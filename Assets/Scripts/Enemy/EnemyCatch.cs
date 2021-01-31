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
    public GameObject townCover;
    public GameObject parkingLotExit;
    public GameObject parkingLotEntrance;
    public GameObject playgroundExit;
    public GameObject playgroundEntrance;
    public GameObject townExit;
    public GameObject townEntrance;
    public GameObject catchImage;
    public GameObject hubCover;
    public Text caughtDialogue;

    [TextArea(3, 10)]
    public string[] dialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioManager.instance.Play("Caught");
            AudioManager.instance.Play("CaughtScream");
            player.GetComponent<PlayerMovement>().canMove = false;
            caughtDialogue.text = dialogue[Random.Range(0, dialogue.Length)];
            player.transform.position = returnPoint.transform.position;
            playgroundCover.SetActive(false);
            parkingLotCover.SetActive(false);
            townCover.SetActive(false);
            townEntrance.SetActive(false);
            parkingLotEntrance.SetActive(false);
            townExit.SetActive(true);
            parkingLotExit.SetActive(true);
            playgroundEntrance.SetActive(false);
            playgroundExit.SetActive(true);
            hubCover.SetActive(true);
            catchImage.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
