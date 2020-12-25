using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if(!audioData.isPlaying)
                audioData.Play();

            rigidBody.AddRelativeForce(Vector3.up);
        }
        else
            audioData.Stop();

        if (Input.GetKey(KeyCode.A) && (!Input.GetKey(KeyCode.D))) // Go right
        {
            transform.Rotate(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.D) && (!Input.GetKey(KeyCode.A))) // Go left
        {
            transform.Rotate(-Vector3.forward);
        }

    }
}
