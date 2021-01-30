﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea(3, 10)]
    public string[] sentences;

    public Sprite npcFace;
    public string name;
}
