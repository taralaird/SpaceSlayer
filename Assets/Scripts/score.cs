using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public TextMeshProUGUI scoreText3;
    public TextMeshProUGUI name1;
    public TextMeshProUGUI name2;
    public TextMeshProUGUI name3;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Main Scene Loaded");
        // if in first place
        if (PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("1st"))
        {
            PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("2nd"));
            PlayerPrefs.SetInt("2nd", PlayerPrefs.GetInt("1st"));
            PlayerPrefs.SetInt("1st", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2"));
            PlayerPrefs.SetString("name2", PlayerPrefs.GetString("name1"));
            PlayerPrefs.SetString("name1", PlayerPrefs.GetString("username"));
        }
        // if in 2nd place
        else if (PlayerPrefs.GetInt("score") < PlayerPrefs.GetInt("1st") &&
                 PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("2nd"))
        {
            PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("2nd"));
            PlayerPrefs.SetInt("2nd", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2"));
            PlayerPrefs.SetString("name2", PlayerPrefs.GetString("username"));
        }
        // if in 3rd place
        else if (PlayerPrefs.GetInt("score") < PlayerPrefs.GetInt("2nd") &&
                 PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt(("3rd")))
        {
            PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("username"));
        }
        // if tie first place, player gets second place
        else if (PlayerPrefs.GetInt("score") == PlayerPrefs.GetInt("1st"))
        {
            PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("2nd"));
            PlayerPrefs.SetInt("2nd", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("name2"));
            PlayerPrefs.SetString("name2", PlayerPrefs.GetString("username"));
        }
        // if tie second place, player gets third place
        else if ((PlayerPrefs.GetInt("score") == PlayerPrefs.GetInt("2nd")))
        {
            PlayerPrefs.SetInt("3rd", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetString("name3", PlayerPrefs.GetString("username"));
        }

        // if tied third place, player gets fourth place (not on leaderboard)
        scoreText1.text = PlayerPrefs.GetInt(("1st")).ToString();
        scoreText2.text = PlayerPrefs.GetInt(("2nd")).ToString();
        scoreText3.text = PlayerPrefs.GetInt(("3rd")).ToString();
        name1.text = PlayerPrefs.GetString("name1");
        name2.text = PlayerPrefs.GetString("name2");
        name3.text = PlayerPrefs.GetString("name3");
    }

    public void resetLeaderboard()
    {
        scoreText1.text = "0";
        scoreText2.text = "0";
        scoreText3.text = "0";
        name1.text = "-----";
        name2.text = "-----";
        name3.text = "-----";
        PlayerPrefs.SetFloat("1st", 0);
        PlayerPrefs.SetFloat("2nd", 0);
        PlayerPrefs.SetFloat("3rd", 0);
        PlayerPrefs.SetString("name3", "-----");
        PlayerPrefs.SetString("name2", "-----");
        PlayerPrefs.SetString("name1", "-----");
    }
}