using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseScreen;

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.Locked;
        pauseScreen.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        pauseScreen.SetActive(true);
    }
}
