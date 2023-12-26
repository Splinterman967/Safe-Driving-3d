using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarDrive : MonoBehaviour
{
    public int Score;
    public float speedZed;
    public float speed;
    public float turnSpeed;
    public float gravityMultiplier;
    public int clock;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        clock = 0;
    }
    private void Update()
    {
        speedMeter();
        increaseScorByTime();
     
    }

    void speedMeter()
    {

        speedZed = rb.velocity.z;
        speedZed = ((int)speedZed);


        if (speedZed <= 1 && speedZed >= -1)
        {
            speedText.text = "0";
        }
        else if (speedZed < 0)
        {
            speedText.text = (-speedZed).ToString();
        }
        else
        {
            speedText.text = speedZed.ToString();
        }
    }

    void increaseScorByTime()
    {
        float time = Time.realtimeSinceStartup;
        Score += (int)(time);
        scoreText.text = Score.ToString();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.W))
        //{
        //    rb.AddRelativeForce(new Vector3(Vector3.forward.x,0,Vector3.forward.z) * speed * 10);
        //}
        //else if (Input.GetKey(KeyCode.S))
        //{
        //    rb.AddRelativeForce(new Vector3(Vector3.forward.x, 0, Vector3.forward.z) * -speed * 10);
        //}


        //Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        //localVelocity.x = 0;
        //rb.velocity = transform.TransformDirection(localVelocity);

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 forceToAdd = transform.forward;
            forceToAdd.y = 0;
            rb.AddForce(forceToAdd * speed * 10);

            if (Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(Vector3.up * turnSpeed * 10);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(-Vector3.up * turnSpeed * 10);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 forceToAdd = -transform.forward;
            forceToAdd.y = 0;
            rb.AddForce(forceToAdd * speed * 10);


            if (Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(-Vector3.up * turnSpeed * 10);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(Vector3.up * turnSpeed * 10);
            }
        }

        Vector3 locVel = transform.InverseTransformDirection(rb.velocity);
        locVel = new Vector3(0, locVel.y, locVel.z);
        rb.velocity = new Vector3(transform.TransformDirection(locVel).x, rb.velocity.y, transform.TransformDirection(locVel).z);

        //if (Input.GetKey(KeyCode.D))
        //{
        //    rb.AddTorque(Vector3.up * turnSpeed * 10);
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    rb.AddTorque(-Vector3.up * turnSpeed * 10);
        //}

        rb.AddForce(Vector3.down * gravityMultiplier * 10);


    }
}