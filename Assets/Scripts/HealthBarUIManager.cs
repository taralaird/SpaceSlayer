using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUIManager : MonoBehaviour
{
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    private PlayerHealth playerHealth;
    private float health;

    void Update()
    {
        GameObject playerGameObject = GameObject.FindWithTag("Player");
        PlayerHealth playerHealth = playerGameObject.GetComponent<PlayerHealth>();
        float health = playerHealth.playersHealth;

        if (health >= 3)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(true);
        }

        if (health == 2)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(true);
            Heart3.gameObject.SetActive(false);
        }

        if (health == 1)
        {
            Heart1.gameObject.SetActive(true);
            Heart2.gameObject.SetActive(false);
            Heart3.gameObject.SetActive(false);
        }

        if (health < 1)
        {
            Heart1.gameObject.SetActive(false);
            Heart2.gameObject.SetActive(false);
            Heart3.gameObject.SetActive(false);
        }
    }
}