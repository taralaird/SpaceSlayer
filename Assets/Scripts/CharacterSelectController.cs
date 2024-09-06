using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectController : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public TextMeshProUGUI name;
    public Image charSprite;

    private int selectedChar = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedChar"))
        {
            selectedChar = 0;
        }
        else
        {
            Load();
        }

        UpdateChar(selectedChar);
    }

    public void NextOption()
    {
        selectedChar++;

        if (selectedChar >= characterDB.CharCount)
        {
            selectedChar = 0;
        }

        UpdateChar(selectedChar);
        Save();
    }

    public void PrevOption()
    {
        selectedChar--;

        if (selectedChar < 0)
        {
            selectedChar = characterDB.CharCount - 1;
        }

        UpdateChar(selectedChar);
        Save();
    }

    public void UpdateChar(int selected)
    {
        Character character = characterDB.GetChar(selected);
        charSprite.sprite = character.icon;
        name.text = character.name;
    }

    private void Load()
    {
        selectedChar = PlayerPrefs.GetInt("selectedChar");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedChar", selectedChar);
    }
}