using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float bulletSpeed = 1000;
    public GameObject bullet;
    public GameObject bulletHole;

    AudioSource bulletAudio;

    // Start is called before the first frame update
    void Start()
    {
        // play audio
        bulletAudio = GetComponent<AudioSource>();
    }

    void Fire()
    {
        GameObject tempBullet =
            Instantiate<GameObject>(bullet, bulletHole.transform.position, bulletHole.transform.rotation);
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletSpeed);

        // play audio
        bulletAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
}