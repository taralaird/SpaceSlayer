using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool isPaused;

    void Start()
    {
        PauseGame(false);
    }

    private void Update()
    {
        //Debug.Log("pause update");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("pressed escape);
            if (isPaused)
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
        }
    }

    public void PauseGame(bool paused)
    {
        if (paused)
        {
            pauseCanvas.SetActive(true);
        }
        else
        {
            pauseCanvas.SetActive(false);
        }

        isPaused = paused;
        Time.timeScale = paused ? 0 : 1;
    }

    public void MainMenu()
    {
        // set player pref score
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("scoreNow"));
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ButtonClicked()
    {
        Debug.Log("Button Clicked");
    }
}