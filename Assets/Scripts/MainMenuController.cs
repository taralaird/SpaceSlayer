using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainScreen;
    public TMP_InputField usernameInput;
    public string Username;
    public GameObject char0;
    public GameObject char1;

    // Start is called before the first frame update
    void Start()
    {
        StartGame(true);
        if (PlayerPrefs.GetInt("selectedChar") == 0)
        {
            char0.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("selectedChar") == 1)
        {
            char1.SetActive(true);
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("selectedChar") == 0)
        {
            char0.SetActive(true);
            char1.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("selectedChar") == 1)
        {
            char1.SetActive(true);
            char0.SetActive(false);
        }
    }

    public void StartGame(bool start)
    {
        if (start)
        {
            mainScreen.SetActive(true);
        }
        else
        {
            mainScreen.SetActive(false);
        }

        Time.timeScale = start ? 0 : 1;
    }

    public void LoadGame()
    {
        Username = usernameInput.text;
        if (Username.Length < 1)
        {
            Debug.Log("name is empty");
            Username = "NoName";
        }

        // set username to prefs
        PlayerPrefs.SetString("username", Username);
        Debug.Log("player prefs " + PlayerPrefs.GetString("username"));
        PlayerPrefs.SetInt("scoreNow", 0);

        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}