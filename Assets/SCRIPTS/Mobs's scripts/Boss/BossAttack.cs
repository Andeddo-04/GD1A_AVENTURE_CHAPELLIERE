using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{   
    public BossMovement bossMovement;

    public GameObject rangeATK, meleATK, cacATK;

    private Transform playerTransform;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        if (bossMovement.playerAtCAC)
        {
            StartCoroutine(Attack_AT_CAC());
        }

        if (bossMovement.playerAtMELE)
        {
            StartCoroutine(Attack_AT_MELE());
        }

        if (bossMovement.playerAtRANGE)
        {
            StartCoroutine(Attack_AT_RANGE());
        }
    }

    public void DoDamages(GameObject _gameObjectToBeDeactivated)
    {
        Debug.Log("heheheha");
        _gameObjectToBeDeactivated.SetActive(false);
    }

    public IEnumerator Attack_AT_CAC()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        cacATK.transform.rotation = Quaternion.LookRotation(direction);
        cacATK.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DoDamages(cacATK);
    }

    public IEnumerator Attack_AT_MELE()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        meleATK.transform.rotation = Quaternion.LookRotation(direction);
        meleATK.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DoDamages(meleATK);
    }

    public IEnumerator Attack_AT_RANGE()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        rangeATK.transform.rotation = Quaternion.LookRotation(direction);
        rangeATK.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        DoDamages(rangeATK);
    }

}
