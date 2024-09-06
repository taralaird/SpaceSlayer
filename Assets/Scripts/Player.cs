using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    // turn speed variable
    public float turnSpeed = 20f;
    public float moveSpeed = 0.25f;

    // animator component
    Animator m_Animator;

    // rigid body component
    Rigidbody m_Rigidbody;

    // vector
    Vector3 m_Movement;

    // create and store a rotation 
    Quaternion m_Rotation = Quaternion.identity;

    // audio source
    AudioSource m_AudioSource;


    // Start is called before the first frame update
    void Start()
    {
        // set reference to the animator component
        m_Animator = GetComponent<Animator>();
        // set reference to the rigid body component
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame, changed to FixedUpdate to make sure vector and rotation are set in time with the OnAnimatorMove
    void FixedUpdate()
    {
        // set/retrieve value of the axis and store it 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // normalize the vector/character so it always moves the same speed
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        // identify if there is player input
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        // set is walking to hor or vert input
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        // set the is walking animator 
        m_Animator.SetBool("IsWalking", isWalking);

        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        // calculate the characters forward vector 
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);

        // set the rotation 
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    IEnumerator playerSpeedBoost()
    {
        moveSpeed = moveSpeed + 3;
        yield return new WaitForSeconds(7);
        moveSpeed = moveSpeed - 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedBoostPU"))
        {
            other.gameObject.SetActive(false);
            StartCoroutine(playerSpeedBoost());
            PlayerPrefs.SetInt("scoreNow", PlayerPrefs.GetInt("scoreNow") + 50);
            GameObject.Find("ScoreNumber").GetComponent<TextMeshProUGUI>().text =
                PlayerPrefs.GetInt("scoreNow").ToString();
        }
    }


    // allows for root motion 
    void OnAnimatorMove()
    {
        // movement
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * Time.fixedDeltaTime * moveSpeed);
        // rotation   
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}