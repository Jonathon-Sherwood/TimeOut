using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Allows all scripts to call this.

    public int toyCountHub = 0;
    public int toyCountRm1 = 0;
    public int toyCountRm2 = 0;
    public int toyCountRm3 = 0;
    public int toyCountRm4 = 0;

    public List<GameObject> toys;
    public List<Quests> children;
    public GameObject currentQuestToy;
    public bool hasToy = false;
    [HideInInspector] public bool onQuest;
    [HideInInspector] public bool runOnce = true;

    private void Awake()
    {

            instance = this;

        foreach(GameObject child in GameObject.FindGameObjectsWithTag("Child"))
        {
            children.Add(child.GetComponent<Quests>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentQuestToy == null && !onQuest)
        {
            if (children.Count > 0)
            {
                children[Random.Range(0, children.Count)].isQuest = true;
            }
        }

        if ((currentQuestToy != null) && !hasToy && onQuest)
        {
            MoveToy();
        }
    }

    public void MoveToy()
    {
        if (runOnce)
        {
            GameObject.Find(currentQuestToy.name.ToString()).layer = 9;
            runOnce = false;
        }
    }

}
