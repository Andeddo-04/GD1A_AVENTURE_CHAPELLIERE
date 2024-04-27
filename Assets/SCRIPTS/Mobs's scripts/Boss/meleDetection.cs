using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleDetection : MonoBehaviour
{
    private BossMovement playerAtMELE;

    void Start()
    {
        playerAtMELE = FindObjectOfType<BossMovement>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAtMELE.meleStatusChanger(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerAtMELE.meleStatusChanger(false);
        }
    }
}
