using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectInGameController : MonoBehaviour
{
    public GameObject char0;
    public GameObject char1;
    public GameObject cam0;
    public GameObject cam1;
    public GameObject end0;
    public GameObject end1;
    public GameObject enemies0;
    public GameObject enemies1;

    void Start()
    {
        if (PlayerPrefs.GetInt("selectedChar") == 0)
        {
            char0.SetActive(true);
            cam0.SetActive(true);
            end0.SetActive(true);
            enemies0.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("selectedChar") == 1)
        {
            char1.SetActive(true);
            cam1.SetActive(true);
            end1.SetActive(true);
            enemies1.SetActive(true);
        }
    }
}