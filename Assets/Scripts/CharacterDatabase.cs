using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    public Character[] character;

    public int CharCount
    {
        get { return character.Length; }
    }

    public Character GetChar(int index)
    {
        return character[index];
    }
}