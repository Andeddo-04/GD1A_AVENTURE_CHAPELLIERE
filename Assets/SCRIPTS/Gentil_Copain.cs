using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gentil_Copain : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distanceToStop = 2f; // Distance à laquelle l'entité s'arrêtera
    private Rigidbody2D rb;

    public bool playerInRange = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerInRange)
        {
            Vector2 direction = player.transform.position - transform.position;
            float distance = direction.magnitude;

            if (distance > distanceToStop)
            {
                direction.Normalize();
                rb.velocity = direction; // Vous pouvez modifier la vitesse en multipliant par une valeur
            }
            
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.gameObject;
            playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            rb.velocity = Vector2.zero; // Stopper fluidement le mouvement de l'entité
        }
    }
}
