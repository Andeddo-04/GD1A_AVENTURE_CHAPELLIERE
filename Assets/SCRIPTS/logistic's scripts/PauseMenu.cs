using Rewired;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject settingsWindow, canvasMainMenu, canvasUI, canvasPauseMenu;

    public PlayerMovement playerMovement;

    private Player player;

    private void Update()
    {
        if (player.GetButtonDown("Controller_PauseButton") && playerMovement.useController)
        {
            if (!gameIsPaused)
            {
                Paused();
            }
        } else if (player.GetButtonDown("KeyBoard_PauseButton") && !playerMovement.useController)
        {
            Paused();
        }
    }

    public void ResumeGame()
    {
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
        canvasUI.SetActive(false);
    }

    void Paused()
    {
        canvasPauseMenu.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }
}