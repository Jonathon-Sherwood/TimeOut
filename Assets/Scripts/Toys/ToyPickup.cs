using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyPickup : MonoBehaviour
{
    [Range(0,3)]
    public int roomNum = 0;

    private void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.hasToy = true;
            gameObject.SetActive(false);
        }
    }
}
