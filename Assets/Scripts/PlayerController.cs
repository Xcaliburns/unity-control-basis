using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] private float horsePower = 20.0f;
    [SerializeField] private float turnSpeed = 25.0f;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] List<WheelCollider> alllWheels;
    [SerializeField] int wheelsOnGround;
    private float rpm;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody playerRb;



    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }


    void FixedUpdate()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (IsOnGround())
        {

            //  transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);//for m/s,change3.6 to 2.237
            speedometerText.SetText(speed + " KM/H");
            rpm = (speed % 30) * 300;
            rpmText.SetText(rpm + " RPM");
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in alllWheels)
        {
            if(wheel.isGrounded) {
            wheelsOnGround++;}
        }
        if (wheelsOnGround >= 2)
        {
            return true;
        }
        else
        {
            
            return false;
        }
    }
}
