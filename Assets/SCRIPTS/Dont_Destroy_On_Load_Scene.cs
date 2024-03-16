using UnityEngine;

public class Dont_Destroy_On_Load_Scene : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    // Méthode appellée avant les fonction start
    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
