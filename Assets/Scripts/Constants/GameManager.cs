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

    // Update is called once per frame
    void Update()
    {
        
    }
}
