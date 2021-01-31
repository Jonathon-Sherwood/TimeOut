using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestCounter : MonoBehaviour
{
    public GameObject canvas;
    public Text counter;
    public Sprite[] sprite;
    public SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.toyCount <= 1)
        {
            spr.sprite = sprite[0];
        }
        else if (GameManager.instance.toyCount <= 3)
        {
            spr.sprite = sprite[1];
        }
        else if (GameManager.instance.toyCount <= 5)
        {
            spr.sprite = sprite[2];
        }
        else
        {
            spr.sprite = sprite[3];
        }
        counter.text = GameManager.instance.toyCount.ToString() + "/8";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvas.SetActive(false);
        }
    }
}
