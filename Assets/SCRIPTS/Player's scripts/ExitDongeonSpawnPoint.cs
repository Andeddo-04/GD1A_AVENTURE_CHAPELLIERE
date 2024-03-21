using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDongeonSpawnPoint : MonoBehaviour
{
    public PlayerMovement myPlayerScript;

    void Awake()
    {
        if (myPlayerScript.completeDongeon)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
        }        
    }
}