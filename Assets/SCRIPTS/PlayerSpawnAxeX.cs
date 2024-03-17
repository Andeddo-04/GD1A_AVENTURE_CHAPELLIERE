using UnityEngine;

public class PlayerSpawnAxeX : MonoBehaviour
{
    public GameObject newPosition;
    void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = newPosition.transform.position;
    }
}
