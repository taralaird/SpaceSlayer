using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainMenuChar : MonoBehaviour
{
    public float speed =10;

    private Transform charTransform; 
    // Start is called before the first frame update
    void Start()
    {
         charTransform = GetComponent<Transform> ();
    }
    

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
        charTransform.Rotate(0f, speed, 0f);
    }
}
