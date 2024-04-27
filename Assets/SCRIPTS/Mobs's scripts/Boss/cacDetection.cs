using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cacDetection : MonoBehaviour
{

    private BossMovement playerAtCAC;

    void Start()
    {
        playerAtCAC = FindObjectOfType<BossMovement>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAtCAC.cacStatusChanger(true); 
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAtCAC.cacStatusChanger(false);
        }
    }
}
