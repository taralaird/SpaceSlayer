using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    public GameObject key;
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GameObject() == key)
        {
            Destroy(key);
            Destroy(door);
        }
    }
}