using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDongeon : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private GameObject player;
    public PlayerMovement playerScript;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            playerScript.completeDongeon = true; // Fait passer completeDongeon en true
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
