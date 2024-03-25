using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopainIgnorant : MonoBehaviour
{
    [SerializeField] private Transform areaPoint1; // Premier point de délimitation de la zone
    [SerializeField] private Transform areaPoint2; // Deuxième point de délimitation de la zone

    private Rigidbody2D rb;
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
        
        timeSinceLastRandomMove += Time.deltaTime;
        if (timeSinceLastRandomMove >= 2f)
        {
            ChooseRandomMoveDirection();
            timeSinceLastRandomMove = 0f;
        }
        rb.velocity = randomMoveDirection * 2f;
    }

    void ChooseRandomMoveDirection()
    {
        Vector2 areaSize = areaPoint2.position - areaPoint1.position;
        Vector2 randomPoint = areaPoint1.position + new Vector3(Random.value * areaSize.x, Random.value * areaSize.y);
        randomMoveDirection = (randomPoint - (Vector2)transform.position).normalized;
    }
}
