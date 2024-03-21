using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class transition_scene : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private bool canChangeScene = true;

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //[SerializeField] private GameObject[] deplaceTargets;
    void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.CompareTag("Player") && canChangeScene)
        {   
            SceneManager.LoadScene(sceneName,LoadSceneMode.Single);
            canChangeScene = false;
            StartCoroutine(delaisTransistorAxeX());
            canChangeScene = true;

        }
    }

    IEnumerator delaisTransistorAxeX()
    {
        // Attendre pendant le temps spécifié
        yield return new WaitForSeconds(1f);        
    }
}
