using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    ////////// * Variables * \\\\\\\\\\
    
    private bool isDead = false, isInvicible = false, coroutineIsStarted = false;

    public bool playerAtCAC = false, playerAtMELE = false;

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

            if (playerAtCAC == true && playerAtMELE == true)
            {
                Debug.Log("Attaque en CAC");
                StartCoroutine(Cooldown(3));
            }

            if (playerAtCAC == false && playerAtMELE == true)
            {
                Debug.Log("Attaque en MELE");
                StartCoroutine(Cooldown(3));
            }

            if(playerAtCAC == false && playerAtMELE == false)
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
    }

    public void meleStatusChanger(bool newBool)
    {
        playerAtMELE = newBool;
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
