using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    private bool isDead = false, isInvicible = false;

    public GameObject miniBoss;

    public Rigidbody2D miniBossSripte;

    public SpriteRenderer miniBossSripteRenderer;

    public Transform[] teleportPoints;

    private Transform target, initialPosition;

    private int desPoint;

    //void Awake()
    //{
    //target = teleportPoints[0];
    //}

    void Start()
    {
        StartCoroutine(PremiereTP());
    }

    void Update()
    {
        if (!isDead)
        {
            // faire paterns attaque et autre

            // appeler la coroutine de tp
        }
    }

    public IEnumerator PremiereTP()
    {
        yield return new WaitForSeconds(1f);
        miniBoss.transform.position = teleportPoints[Random.Range(0, 3)].transform.position;
    }

    //public IEnumerator teleportationframes()
    //{
    //isInvicible = true;

    //desPoint = (desPoint + 1) % teleportPoints.Length; // % = reste division
    //target = teleportPoints[desPoint];

    //miniBossSripteRenderer.color = new Color(1f, 1f, 1f, 0f);
    //yield return new WaitForSeconds(0.33f);
    //}

}
