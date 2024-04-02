using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cristal : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private Text interactUI;
    private bool isInRange;
    private GameObject player;

    void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
        interactUI.enabled = false; // Désactiver le texte au début
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        goInCristal();
    }

    void goInCristal()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {   
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}