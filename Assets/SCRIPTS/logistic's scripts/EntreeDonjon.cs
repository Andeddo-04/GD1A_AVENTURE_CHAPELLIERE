using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Rewired;

public class EntreeDonjon : MonoBehaviour
{
    public string sceneName;
    private TextMeshProUGUI interactUI;
    public bool isInRange;
    private Player player;
    public int playerId = 0;

    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (isInRange && PlayerMovement.instance.useController == true && player.GetButtonDown("Controler_Interact"))

            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        
        // Vérifier si le joueur est dans la zone et s'il appuie sur la touche E
        if (isInRange && PlayerMovement.instance.useController == false && player.GetButtonDown("KeyBoard_Interact"))
        {
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
