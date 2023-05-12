using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horsePower = 20.0f;    
    [SerializeField] private float turnSpeed = 25.0f;
    [SerializeField] GameObject centerOfMass;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass=centerOfMass.transform.position;
    }


    void FixedUpdate()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //  transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        playerRb.AddRelativeForce(Vector3.forward *verticalInput* horsePower); 
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
