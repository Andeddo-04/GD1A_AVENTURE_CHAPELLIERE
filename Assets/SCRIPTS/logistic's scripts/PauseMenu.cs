using Rewired;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string levelToLoad;

    public float cursorSpeed = 1.0f;

    public static bool gameIsPaused = false;

    public GameObject settingsWindow, canvasMainMenu, canvasUI, canvasPauseMenu;

    public PlayerMovement playerMovement;

    public playerHealth playerHealth;

    private Player player;

    private void Start()
    {
        player = ReInput.players.GetPlayer(0); // Obtient le joueur 0 (premier joueur) dans Rewired
    }

    private void Update()
    {
        if (canvasMainMenu.activeSelf == false)
        {
            if (player.GetButtonDown("KeyBoard_PauseButton") && !playerMovement.useController)
            {
                if (!gameIsPaused)
                {
                    Paused();
                }
            }
            
            if (player.GetButtonDown("Controler_PauseButton") && playerMovement.useController)
            {
                if (!gameIsPaused)
                {
                    Paused();
                }
            }
        }
    }

    public void ResumeGame()
    {
        canvasPauseMenu.SetActive(false);
        canvasMainMenu.SetActive(false);
        playerMovement.HideAndLockCursor();

        canvasPauseMenu.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Paused()
    {
        canvasPauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
}