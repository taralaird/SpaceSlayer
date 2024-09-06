using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GameObject.Find("ScoreNumber").GetComponent<TextMeshProUGUI>();
        //Debug.Log(PlayerPrefs.GetInt("scoreNow", Score));
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.transform.name);
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            // set score Text UI
            PlayerPrefs.SetInt("scoreNow", PlayerPrefs.GetInt("scoreNow") + 100);
            scoreText.text = PlayerPrefs.GetInt("scoreNow").ToString();

            Debug.Log("Score" + PlayerPrefs.GetInt("scoreNow"));
            //Debug.Log("player prefs" + PlayerPrefs.GetInt("scoreNow"));

            Destroy(this.gameObject);
        }

        if (collision.transform.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}