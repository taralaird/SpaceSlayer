using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateScore : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        scoreText.text = PlayerPrefs.GetInt("scoreNow").ToString();
        if (SceneManager.GetSceneByName("Level2").isLoaded)
        {
            PlayerPrefs.SetInt("level2StartScore", PlayerPrefs.GetInt("scoreNow"));
            Debug.Log("Level 2 start score: "+PlayerPrefs.GetInt("level2StartScore"));
        }
        if (SceneManager.GetSceneByName("Level3").isLoaded)
        {
            PlayerPrefs.SetInt("level3StartScore", PlayerPrefs.GetInt("scoreNow"));
            Debug.Log("Level 3 start score: "+PlayerPrefs.GetInt("level3StartScore"));

        }

    }
}
