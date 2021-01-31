using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Allows all scripts to call this.

    public int toyCount = 0;

    public List<GameObject> toys;
    public List<Quests> children;
    public GameObject currentQuestToy;
    public GameObject canvas;
    public bool hasToy = false;
    [HideInInspector] public bool onQuest;
    [HideInInspector] public bool runOnce = true;

    private void Awake()
    {

            instance = this;
        canvas.SetActive(true);

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

        if(toyCount >= 8)
        {
            SceneManager.LoadScene(2);
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
