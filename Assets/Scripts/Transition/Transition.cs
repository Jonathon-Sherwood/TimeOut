using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Transition : MonoBehaviour
{
    public GameObject covers;
    public GameObject hubcovers;
    public PolygonCollider2D confiner;
    public CinemachineConfiner cmConfiner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            covers.SetActive(true);
            cmConfiner.m_BoundingShape2D = confiner;
            hubcovers.SetActive(false);

        }
    }
}
