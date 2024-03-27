using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GentilCopainCorrompu : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distanceToStop; // Distance à laquelle l'entité s'arrêtera
    [SerializeField] private Transform areaPoint1; // Premier point de délimitation de la zone
    [SerializeField] private Transform areaPoint2; // Deuxième point de délimitation de la zone

    private Rigidbody2D rb;
    public bool playerInRange = false;
    private Vector2 randomMoveDirection;
    private float timeSinceLastRandomMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeSinceLastRandomMove = Random.Range(0f, 2f); // Commencer avec un délai aléatoire
        ChooseRandomMoveDirection();
    }

    void Update()
    {
        if (playerInRange)
        {
            Vector2 direction = player.transform.position - transform.position;
            float distance = direction.magnitude; // .magnitude permet d'avoir la distance du vecteur, dans le cas ci, c'est la distance entre l'entitée et le joueur

            if (distance > distanceToStop)
            {
                rb.velocity = direction.normalized * 2f; // Vous pouvez modifier la vitesse en multipliant par une valeur
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }

        else
        {
            timeSinceLastRandomMove += Time.deltaTime;
            if (timeSinceLastRandomMove >= 2f)
            {
                ChooseRandomMoveDirection();
                timeSinceLastRandomMove = 0f;
            }
            rb.velocity = randomMoveDirection * 2f;
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

    void ChooseRandomMoveDirection()
    {
        Vector2 areaSize = areaPoint2.position - areaPoint1.position;
        Vector2 randomPoint = areaPoint1.position + new Vector3(Random.value * areaSize.x, Random.value * areaSize.y);
        randomMoveDirection = (randomPoint - (Vector2)transform.position).normalized;
    }
}
