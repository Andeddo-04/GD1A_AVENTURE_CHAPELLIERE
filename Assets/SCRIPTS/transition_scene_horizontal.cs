using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class transition_scene_horizontal : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //[SerializeField] private GameObject[] deplaceTargets;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
            StartCoroutine(delaisTransistorAxeX());
        }
    }

    IEnumerator delaisTransistorAxeX()
    {
        // Attendre pendant le temps spécifié
        yield return new WaitForSeconds(1f);        
    }
}
