using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
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
            rigidBody.AddRelativeForce(Vector3.up);
        }
        if (Input.GetKey(KeyCode.A) && (!Input.GetKey(KeyCode.D))) // Go right
        {
            transform.Rotate(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.D) && (!Input.GetKey(KeyCode.A))) // Go left
        {
            transform.Rotate(-Vector3.forward);
        }

        if (Input.GetKey(KeyCode.W) && (!Input.GetKey(KeyCode.S))) // Go backwards
        {
            transform.Rotate(Vector3.right);
        }
        if (Input.GetKey(KeyCode.S) && (!Input.GetKey(KeyCode.W))) // Go forward
        {
            transform.Rotate(-Vector3.right);
        }

    }
}
