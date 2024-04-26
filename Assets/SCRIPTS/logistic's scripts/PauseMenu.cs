using Rewired;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public string levelToLoad;

    public static bool gameIsPaused = false;

    public GameObject settingsWindow, canvasMainMenu, canvasUI, canvasPauseMenu;

    public PlayerMovement playerMovement;

    public playerHealth playerHealth;

    private Player player;

    private void Update()
    {
        if (canvasMainMenu.activeSelf == false)
        {
            if (player.GetButtonDown("Controller_PauseButton") && playerMovement.useController)
            {
                if (!gameIsPaused)
                {
                    Paused();
                }
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && !playerMovement.useController)
            {
                Paused();
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

    public void MainMenuButton()
    {
        canvasMainMenu.SetActive(true);
        canvasPauseMenu.SetActive(false);
        canvasUI.SetActive(false);

        playerHealth.instance.Respawn();
    }

    void Paused()
    {
        canvasPauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
}