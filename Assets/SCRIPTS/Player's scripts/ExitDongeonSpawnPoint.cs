using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDongeonSpawnPoint : MonoBehaviour
{
    private GameObject player;
    public PlayerMovement myPlayerScript;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myPlayerScript = player.GetComponent<PlayerMovement>();
    }

    void Start()
    {
        if (myPlayerScript.completeDongeon)
        {
            player.transform.position = transform.position;
        }
    }
}