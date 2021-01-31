using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizedTeacher : MonoBehaviour
{
    public float targetTime;
    public float waitTime = 5;
    public List<Sprite> sprites;
    public SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        targetTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        //Returns to patrol after not finding the player
        if (Time.time > targetTime + waitTime)
        {
            spr.sprite = sprites[Random.Range(0, sprites.Count)];
            targetTime = Time.time;
        }
    }
}
