using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Speech : MonoBehaviour
{
    public GameObject speechBubble;
    public Dialogue[] dialogue;
    [HideInInspector] public Quests quest;
    public int dialogueNum;
    private bool canSpeak;
    public string npcName;

    private void Start()
    {
        quest = GetComponent<Quests>();
    }

    // Update is called once per frame
    void Update()
    {

        if(canSpeak && Input.GetKeyDown(KeyCode.E))
        {
            ChooseAudio();
            speechBubble.SetActive(false);
            if (quest.isQuest && !quest.hasQuestItem)
            {
                dialogueNum = 0;
            }
            else if (quest.hasQuestItem && quest.isQuest)
            {
                AudioManager.instance.Play("QuestComplete");
                GameManager.instance.onQuest = false;
                dialogueNum = 1;
                GameManager.instance.currentQuestToy = null;
                GameManager.instance.hasToy = false;
                quest.isQuest = false;
                GameManager.instance.children.Remove(this.quest);
                GameManager.instance.toyCount++;
            }
            else
            {
                dialogueNum = Random.Range(2, dialogue.Length);
            }

            dialogue[dialogueNum].name = npcName;
            dialogue[dialogueNum].npcFace = GetComponent<SpriteRenderer>().sprite;
            dialogue[dialogueNum].speaker = this;
            TriggerDialogue();
        }

        if(canSpeak && Input.GetKeyDown(KeyCode.Space))
        {
            DialogueManager.instance.DisplayNextSentence(dialogue[dialogueNum], quest.toyQuestNum);
        }
    }

    public void ChooseAudio()
    {
        if(quest.toyQuestNum == 0)
        {
            AudioManager.instance.Play("Scream0");
        }
        else if (quest.toyQuestNum == 1)
        {
            AudioManager.instance.Play("Scream1");
        }
        else if(quest.toyQuestNum == 2)
        {
            AudioManager.instance.Play("Scream2");
        }
        else if (quest.toyQuestNum == 3)
        {
            AudioManager.instance.Play("Scream3");
        }
        else if (quest.toyQuestNum == 4)
        {
            AudioManager.instance.Play("Scream4");
        }
        else if (quest.toyQuestNum == 5)
        {
            AudioManager.instance.Play("Scream5");
        }
        else if (quest.toyQuestNum == 6)
        {
            AudioManager.instance.Play("Scream6");
        }
        else if (quest.toyQuestNum == 7)
        {
            AudioManager.instance.Play("Scream7");
        }
        else
        {
            AudioManager.instance.Play("Scream8");
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[dialogueNum], quest.toyQuestNum);
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
           // if (!DialogueManager.instance.anim.GetBool("IsOpen")){ return; }
            DialogueManager.instance.EndDialogue(dialogue[dialogueNum]);
            speechBubble.SetActive(false);
            canSpeak = false;
        }
    }
}
