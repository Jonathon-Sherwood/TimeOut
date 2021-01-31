using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Transition : MonoBehaviour
{
    public bool entrance;
    public GameObject covers;
    public GameObject hubcovers;
    public GameObject enemy;
    public GameObject spawnLocation;
    public GameObject returnLocation;
    public PolygonCollider2D confiner;
    public CinemachineConfiner cmConfiner;
    public GameObject oppositeCollider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            covers.SetActive(true);
            cmConfiner.m_BoundingShape2D = confiner;
            hubcovers.SetActive(false);

            if(entrance)
            {
                enemy.transform.position = returnLocation.transform.position;
                enemy.SetActive(false);
            } else
            {
                enemy.SetActive(true);
                enemy.transform.position = spawnLocation.transform.position;
            }
            oppositeCollider.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
