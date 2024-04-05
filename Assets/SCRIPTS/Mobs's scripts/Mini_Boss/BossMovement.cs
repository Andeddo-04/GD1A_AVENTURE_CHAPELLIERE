using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    ////////// * Variables * \\\\\\\\\\
    
    private bool isDead = false, isInvicible = false, coroutineIsStarted = false;

    public bool playerAtCAC = false, playerAtMELE = false, playerAtRANGE = false;

    public GameObject miniBoss;

    public Rigidbody2D miniBossSripte;

    public SpriteRenderer miniBossSripteRenderer;

    public Transform[] teleportPoints;

    void Start()
    {
        //StartCoroutine(PremiereTP());
    }

    void Update()
    {
        if (!isDead)
        {
            // faire paterns attaque et autre

            if (playerAtCAC)
            {
                Debug.Log("Attaque en CAC");
                StartCoroutine(Cooldown(3));
            }

            if (playerAtMELE)
            {
                Debug.Log("Attaque en MELE");
                StartCoroutine(Cooldown(3));
            }

            if (playerAtRANGE)
            {
                Debug.Log("Attaque a distance");
                StartCoroutine(Cooldown(3));
            }

            //if (coroutineIsStarted == false)
            //{
            //StartCoroutine(TeleportationFrames());

            //}

        }
    }

    ////////// * Méthode pour changer les bool depuis un autre script * \\\\\\\\\\
    public void cacStatusChanger(bool newBool)
    {
        playerAtCAC = newBool;

        if (playerAtCAC)
        {
            playerAtMELE = false;
            playerAtRANGE = false;
        }
    }

    public void meleStatusChanger(bool newBool)
    {
        playerAtMELE = newBool;

        if (playerAtMELE)
        {
            playerAtCAC = false;
            playerAtRANGE = false;
        }
    }

    public void rangeStatusChanger(bool newBool)
    {
        playerAtRANGE = newBool;

        if (playerAtRANGE)
        {
            playerAtMELE = false;
            playerAtCAC = false;
        }
    }

    ////////// * Coroutines * \\\\\\\\\\

    public IEnumerator PremiereTP()
    {
        yield return new WaitForSeconds(1f);
        miniBoss.transform.position = teleportPoints[Random.Range(0, 4)].transform.position;
        StartCoroutine(Cooldown(1));
    }

    public IEnumerator TeleportationFrames()
    {
        coroutineIsStarted = true;

        isInvicible = true;

        Debug.Log("Attente");
        yield return new WaitForSeconds(3f);
        
        
        miniBoss.transform.position = teleportPoints[Random.Range(0, 4)].transform.position;

        isInvicible = false;

        coroutineIsStarted = false;
    }

    public IEnumerator Cooldown(int _delaisCooldown)
    {
        yield return new WaitForSeconds(_delaisCooldown);
    }

}
