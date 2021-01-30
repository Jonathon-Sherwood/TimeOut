using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public Speech speaker;
    public bool hasQuestItem;
    public bool isQuest;

    [Range(0, 11)]
    public int toyQuestNum;
    // Start is called before the first frame update
    void Start()
    {
        speaker = GetComponent<Speech>();
        if(isQuest)
        {

        }


    }

    // Update is called once per frame
    void Update()
    {
        speaker.dialogue[speaker.dialogueNum].isQuest = isQuest;
        if (isQuest) { GameManager.instance.onQuest = true; }

        if (GameManager.instance.hasToy && GameManager.instance.currentQuestToy == GameManager.instance.toys[toyQuestNum])
        {
            hasQuestItem = true;
        }
    }
}
