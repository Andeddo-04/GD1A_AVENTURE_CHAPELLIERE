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
        if (isInRange && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown("PS4Square")))
        {
            // Charger la scène spécifiée
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}