using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    public CanvasGroup levelEndBackgroundCanvasGroup;
    public AudioSource exitAudio;
    public CanvasGroup deadBackgroundCanvasGroup;
    public AudioSource caughtAudio;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerDead;
    float m_Timer;
    bool m_HasAudioPlayed;
    private int Score;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void DeadPlayer()
    {
        m_IsPlayerDead = true;
        //Debug.Log("Level 3 start score Dead: "+PlayerPrefs.GetInt("level3StartScore"));
    }

    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(levelEndBackgroundCanvasGroup, false, exitAudio);
        }
        else if (m_IsPlayerDead)
        {
            EndLevel(deadBackgroundCanvasGroup, true, caughtAudio);
        }
    }

    //“If m_IsPlayerAtExit is true,callEndLevel.If it isn’t true,then check if m_IsPlayerDead is true;if it is, callEndLevel.”
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if (m_Timer > fadeDuration + displayImageDuration && SceneManager.GetSceneByName("Level1").isLoaded)
        {
            if (doRestart)
            {
                PlayerPrefs.SetInt("scoreNow", 0);
                SceneManager.LoadScene("Level1");
            }
            else
            {
                SceneManager.LoadScene("Level2");
            }
        }
        else if (m_Timer > fadeDuration + displayImageDuration && SceneManager.GetSceneByName("Level2").isLoaded)
        {
            if (doRestart)
            {
                PlayerPrefs.SetInt("scoreNow", PlayerPrefs.GetInt("level2StartScore"));
                SceneManager.LoadScene("Level2");
            }
            else
            {
                SceneManager.LoadScene("Level3");
            }
        }
        else if (m_Timer > fadeDuration + displayImageDuration && SceneManager.GetSceneByName("Level3").isLoaded)
        {
            if (doRestart)
            {
                PlayerPrefs.SetInt("scoreNow", PlayerPrefs.GetInt("level3StartScore"));
                Debug.Log("Level 3 start score Reload: " + PlayerPrefs.GetInt("level3StartScore"));
                SceneManager.LoadScene("Level3");
            }
            else
            {
                // get player pref score
                Score = PlayerPrefs.GetInt("scoreNow");
                // set player pref score
                PlayerPrefs.SetInt("score", Score);
                SceneManager.LoadScene("Menu");
            }
        }
    }
}