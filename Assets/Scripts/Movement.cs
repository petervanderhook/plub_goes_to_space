using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float main_thrust = 1000;
    [SerializeField] public float main_rotate = 100;
    
    Rigidbody playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        // GetKeyDown() returns true during the one frame the user starts pressing down
        // GetKey() returns true while user holds down the button
        if((Input.GetKey(KeyCode.Space)) || (Input.GetKey(KeyCode.W)))
        {
            playerRigidbody.AddRelativeForce(Vector3.up * main_thrust * Time.deltaTime);
            
        };
    }
    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            playerRigidbody.freezeRotation = true;
            Debug.Log("Turning Left (Rotate z +)");
            transform.Rotate(Vector3.forward * main_rotate * Time.deltaTime);
            playerRigidbody.freezeRotation = false;
        };
        if(Input.GetKey(KeyCode.D))
        {
            playerRigidbody.freezeRotation = true;
            Debug.Log("Turning Right (Rotate z -)");
            transform.Rotate(Vector3.forward * main_rotate * Time.deltaTime * -1);
            playerRigidbody.freezeRotation = false;
        };
    }
}