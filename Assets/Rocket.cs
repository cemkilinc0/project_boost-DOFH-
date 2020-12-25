using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioData;

    Vector3 rotVector;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();

        rotVector = new Vector3(0, 0, 3);
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioData.isPlaying)
                audioData.Play();

            rigidBody.AddRelativeForce(Vector3.up);
        }
        else
            audioData.Stop();
    }

    private void Rotate()
    {

        rigidBody.freezeRotation = true; // take manual control of rotation

        if (Input.GetKey(KeyCode.A) && (!Input.GetKey(KeyCode.D))) // Go right
        {
            transform.Rotate(rotVector);
        }

        if (Input.GetKey(KeyCode.D) && (!Input.GetKey(KeyCode.A))) // Go left
        {
            transform.Rotate(-rotVector);
        }

        rigidBody.freezeRotation = false;
    }
}
