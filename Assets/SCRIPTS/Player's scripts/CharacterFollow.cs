using UnityEngine;

public class CharacterFollow : MonoBehaviour
{
    public GameObject newPosition;
 
    void Update()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = newPosition.transform.position;
    }
}
