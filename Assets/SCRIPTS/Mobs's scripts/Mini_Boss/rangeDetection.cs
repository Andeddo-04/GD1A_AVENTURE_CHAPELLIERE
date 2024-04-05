using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeDetection : MonoBehaviour
{
    private BossMovement playerAtARNGE;

    void Start()
    {
        playerAtARNGE = FindObjectOfType<BossMovement>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAtARNGE.rangeStatusChanger(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAtARNGE.rangeStatusChanger(false);
        }
    }
}
