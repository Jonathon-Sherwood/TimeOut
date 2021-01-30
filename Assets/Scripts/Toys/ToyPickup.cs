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
            if(roomNum == 0)
            {
                GameManager.instance.toyCountRm1++;
            }
            if (roomNum == 1)
            {
                GameManager.instance.toyCountRm2++;
            }
            if (roomNum == 2)
            {
                GameManager.instance.toyCountRm3++;
            }
            if (roomNum == 3)
            {
                GameManager.instance.toyCountRm4++;
            }

            GameManager.instance.toyCountHub++;
            Destroy(gameObject);
        }
    }
}
