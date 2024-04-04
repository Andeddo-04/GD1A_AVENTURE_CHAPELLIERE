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

    void Start()
    {
        StartCoroutine(PremiereTP());
    }

    void Update()
    {
        if (!isDead)
        {
            // faire paterns attaque et autre

            StartCoroutine(TeleportationFrames());
            
        }
    }

    public IEnumerator PremiereTP()
    {
        yield return new WaitForSeconds(1f);
        miniBoss.transform.position = teleportPoints[Random.Range(0, 4)].transform.position;
        StartCoroutine(Cooldown());
    }

    public IEnumerator TeleportationFrames()
    {
        isInvicible = true;

        Debug.Log("Attente");
        yield return new WaitForSeconds(3f);
        
        miniBossSripteRenderer.color = new Color(1f, 1f, 1f, 0f);
        miniBoss.transform.position = teleportPoints[Random.Range(0, 3)].transform.position;

        Debug.Log("Nouvelle attente");
        yield return new WaitForSeconds(3f);
        miniBossSripteRenderer.color = new Color(1f, 1f, 1f, 0f);

        isInvicible = false;
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
    }

}
