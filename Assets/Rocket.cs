using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioData;

    [SerializeField] float rcsThruster = 150f;
    [SerializeField] float mainThruster = 1000f;
    //Vector3 rotVector;

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

        //rotVector = new Vector3(0, 0, 3);
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You're safe!"); // replace with action later
                break;
            case "Fuel":
                Debug.Log("Getting juice!");
                // increase fuel bar
                break;

            default:
                Debug.Log("You died mate! GitGud!"); 
                // kill the player. Death to the normies!
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!audioData.isPlaying)
                audioData.Play();

            float boostThisFrame = mainThruster * Time.deltaTime;
            rigidBody.AddRelativeForce(Vector3.up * boostThisFrame);
        }
        else
            audioData.Stop();
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

        float rotateThisFrame = rcsThruster * Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && (!Input.GetKey(KeyCode.D))) // Go right
        {

            transform.Rotate(Vector3.forward * rotateThisFrame);
        }

        if (Input.GetKey(KeyCode.D) && (!Input.GetKey(KeyCode.A))) // Go left
        {
            transform.Rotate(-Vector3.forward * rotateThisFrame);
        }

        rigidBody.freezeRotation = false;
    }
}
