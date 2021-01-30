using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea(3, 10)]
    public string[] sentences;

    [HideInInspector]public Sprite npcFace;
    [HideInInspector]public string name;
    public bool isQuest;
    public Speech speaker;
}
