using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsWindow, canvasMainMenu, canvasUI;

    public PlayerMovement playerMovement;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
        canvasMainMenu.SetActive(false);
        canvasUI.SetActive(true);
        playerMovement.HideAndLockCursor();
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
}