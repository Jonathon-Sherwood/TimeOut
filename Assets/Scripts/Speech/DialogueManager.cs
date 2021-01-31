using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Image image;
    public Animator anim;
    private Speech speaker;

    private void Awake()
    {
        //Turns the gamemanager into a singleton.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, int questNum)
    {
        anim.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        image.sprite = dialogue.npcFace;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence(dialogue, questNum);
    }

    public void DisplayNextSentence(Dialogue dialogue, int questNum)
    {
        if(sentences.Count == 0)
        {
            if(dialogue.isQuest)
            {
                GameManager.instance.currentQuestToy = GameManager.instance.toys[questNum];
            }
            EndDialogue(dialogue);
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue(Dialogue dialogue)
    {
        anim.SetBool("IsOpen", false);
        if (dialogue.speaker == null) { return; }
        if(!GameManager.instance.hasToy && dialogue.speaker.quest.isQuest && GameManager.instance.currentQuestToy != null)
        {
            GameObject.Find(GameManager.instance.currentQuestToy.name.ToString()).layer = 9;
        }
        AudioManager.instance.Stop("Scream0");
        AudioManager.instance.Stop("Scream1");
        AudioManager.instance.Stop("Scream2");
        AudioManager.instance.Stop("Scream3");
        AudioManager.instance.Stop("Scream4");
        AudioManager.instance.Stop("Scream5");
        AudioManager.instance.Stop("Scream6");
        AudioManager.instance.Stop("Scream7");
    }

}
