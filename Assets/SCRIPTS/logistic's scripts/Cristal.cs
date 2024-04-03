using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Cristal : MonoBehaviour
{
    public string sceneName;
    private TextMeshProUGUI interactUI;
    public bool isInRange;

    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // Vérifier si le joueur est dans la zone et s'il appuie sur la touche E
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Charger la scène spécifiée
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Arrete de me toucher");
            interactUI.enabled = true;
            isInRange = true;

            if (isInRange)
            {
                Debug.Log("Player in range");
            }
            else
            {
                Debug.Log("Player out of range");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Merci bien");
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}