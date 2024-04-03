using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cristal : MonoBehaviour
{
    public string sceneName;
    private Text interactUI;
    public bool isInRange;

    void Start()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
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
        if (collision.collider.gameObject.tag == "Player")
        {
            interactUI.enabled = true;
            isInRange = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            interactUI.enabled = false;
            isInRange = false;
        }
    }
}