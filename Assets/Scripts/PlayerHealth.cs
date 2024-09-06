using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playersHealth = 3;
    public GameEnding gameEnding;

    private bool canTrigger2 = true;
    private bool canTrigger3 = true;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthBoostPU"))
        {
            other.gameObject.SetActive(false);
            PlayerPrefs.SetInt("scoreNow", PlayerPrefs.GetInt("scoreNow") + 50);
            GameObject.Find("ScoreNumber").GetComponent<TextMeshProUGUI>().text =
                PlayerPrefs.GetInt("scoreNow").ToString();
            if (playersHealth < 3)
            {
                playersHealth += 1;
            }

            Debug.Log("player health:" + playersHealth);
        }

        //For the observer enemies (level 1)
        if (other.gameObject.CompareTag("EnemyPOV"))
        {
            playersHealth -= 1;
            Debug.Log("player health:" + playersHealth);

            if (playersHealth < 1)
            {
                gameEnding.DeadPlayer();
            }
        }

        //For the level 2 enemies
        if (other.gameObject.CompareTag("Enemy2POV"))
        {
            if (canTrigger2)
            {
                playersHealth -= 1;
                Debug.Log("player health:" + playersHealth);

                StartCoroutine(ResetEnemy2());
            }

            if (playersHealth < 1)
            {
                gameEnding.DeadPlayer();
            }
        }

        //For the level 3 enemies
        if (other.gameObject.CompareTag("Enemy3POV"))
        {
            if (canTrigger3)
            {
                playersHealth -= 1;
                Debug.Log("player health:" + playersHealth);

                StartCoroutine(ResetEnemy3());
            }

            if (playersHealth < 1)
            {
                gameEnding.DeadPlayer();
            }
        }
    }

    private IEnumerator ResetEnemy2()
    {
        canTrigger2 = false;
        yield return new WaitForSeconds(1f);
        canTrigger2 = true;
    }

    private IEnumerator ResetEnemy3()
    {
        canTrigger3 = false;
        yield return new WaitForSeconds(2f);
        canTrigger3 = true;
    }
}