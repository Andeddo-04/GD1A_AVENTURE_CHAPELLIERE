using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDongeon : MonoBehaviour
{

    public PlayerMovement myPlayerScript;

    void private void Awake()
    {
        if (myPlayerScript.completeDongeon)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        }        
    }
}