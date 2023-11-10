using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputActionReference pauseInput;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameMenus;
    private bool isPause = false;

    private void Update()
    {
        if (pauseInput.action.WasPressedThisFrame())
        {
            if (!isPause)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Pause()
    {
        if (isPause)
            return;

        isPause = true;
        Time.timeScale = 0;

        gameMenus.SetActive(false);
        pauseMenu.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        if (!isPause)
            return;

        isPause = false;
        Time.timeScale = 1;

        gameMenus.SetActive(true);
        pauseMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ResetGame()
    {
        Resume();
        SceneManager.LoadScene("InGame");
    }
}
