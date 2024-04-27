using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeDetection : MonoBehaviour
{
    private BossMovement playerAtRANGE;

    void Start()
    {
        playerAtRANGE = FindObjectOfType<BossMovement>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAtRANGE.rangeStatusChanger(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAtRANGE.rangeStatusChanger(false);
        }
    }
}
