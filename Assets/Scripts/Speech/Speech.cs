using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Speech : MonoBehaviour
{
    public GameObject speechBubble;
    public Dialogue dialogue;
    private bool canSpeak;

    private void Start()
    {
        dialogue.npcFace = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(canSpeak && Input.GetKeyDown(KeyCode.E))
        {
            speechBubble.SetActive(false);
            TriggerDialogue();
        }

        if(canSpeak && Input.GetKeyDown(KeyCode.Space))
        {
            DialogueManager.instance.DisplayNextSentence();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speechBubble.SetActive(true);
            canSpeak = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speechBubble.SetActive(false);
            canSpeak = false;
        }
    }
}
