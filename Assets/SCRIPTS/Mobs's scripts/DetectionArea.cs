using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{

    private Ennemie playerDetection;

    void Start()
    {
        playerDetection = FindObjectOfType<Ennemie>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetection.playerInRangeUpdater(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetection.playerInRangeUpdater(false);
        }
    }
}
