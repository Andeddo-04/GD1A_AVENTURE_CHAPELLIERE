using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

playerHealth playerHealth = collision.transform.GetComponent<playerHealth>();
playerHealth.TakeDamage(10);