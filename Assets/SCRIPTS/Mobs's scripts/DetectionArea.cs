using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{

    private GentilCopainCorrompu playerDetection;

    void Start()
    {
        playerDetection = FindObjectOfType<GentilCopainCorrompu>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetection.VariableChanger(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerDetection.VariableChanger(false);
        }
    }
}
