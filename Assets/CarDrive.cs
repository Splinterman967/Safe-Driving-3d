using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarDrive : MonoBehaviour
{
    public int Score;
    public float speedZed;
    public float speed;
    public float turnSpeed;
    public float gravityMultiplier;

    public bool speedExeed;
    public bool isCrossed;

    public GameObject speedLimit;
    public GameObject dontCross;
    public GameObject scoreMinus;
    public GameObject trafficSign;
    private int Limit;

    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;

    public Rigidbody rb;

   

    void Start()
    {
        Score = 100;
        speedExeed = false;


        StartCoroutine(checkSpeedLimit());
    }
    private void Update()
    {
        speedMeter();
        increaseScorByTime();
        checkTrafficSign();

    }
    void FixedUpdate()
    {
        
        carMovement();

    }

 
    void checkTrafficSign()
    {
        if(trafficSign.GetComponent<Image>().sprite.name == "30 limit")
        {
            Limit = 30;
        }
        else if(trafficSign.GetComponent<Image>().sprite.name == "50 limit")
        {
            Limit = 50;
        }

        if (speedZed > Limit )
        {
            speedExeed = true;
        }
        else
        {
            speedExeed = false;
        }

    }


    IEnumerator checkSpeedLimit()
    {
        
        while(true)
        {
            if (speedExeed)
            {
                speedLimit.SetActive(true);
                speedLimit.GetComponent<Animation>().Play();


                yield return new WaitForSeconds(2);

                speedLimit.SetActive(false);
                speedLimit.GetComponent<Animation>().Stop();

                if (speedExeed)
                {                   
                    Score -= 10;
                    scoreMinus.SetActive(true);
                    yield return new WaitForSeconds(1);
                    scoreMinus.SetActive(false);
                }
            }
            yield return null;          
        }

    }
    void speedMeter()
    {

        speedZed = rb.velocity.z;
        speedZed = ((int)speedZed);


        if (speedZed <= 1 && speedZed >= -1)
        {
            speedText.text = "Speed: 0 ";
        }
        else if (speedZed < 0)
        {
            speedText.text = "Speed : " + (-speedZed).ToString();
        }
        else
        {
            speedText.text = "Speed : " + speedZed.ToString();
        }
    }

    void increaseScorByTime()
    {
        float time = Time.realtimeSinceStartup;
       // Score += (int)(time);
        scoreText.text = "Score : " + Score.ToString();
    }

    
   


    void carMovement()
    {

       

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

    private void OnTriggerEnter(Collider collision)
    {


        if (trafficSign.GetComponent<Image>().sprite.name == "no Overtaking")
        {
            if (collision.CompareTag("Npcar"))
            {

                dontCross.SetActive(true);
                isCrossed = true;
                StartCoroutine(checkIfCroessed());
            }

            if (!collision.CompareTag("Npcar"))
            {

                dontCross.SetActive(true);
                isCrossed = false;
                StartCoroutine(checkIfCroessed());
            }
        }
      
    }

    private void OnTriggerExit(Collider collision)
    {


        if (trafficSign.GetComponent<Image>().sprite.name == "no Overtaking")
        {
            if (collision.CompareTag("Npcar"))
            {

                dontCross.SetActive(true);
                isCrossed = true;
                StartCoroutine(checkIfCroessed());
            }
        }

    }






    IEnumerator checkIfCroessed()
    {

        while (true)
        {
            if (speedExeed)
            {
                speedLimit.SetActive(true);
                speedLimit.GetComponent<Animation>().Play();


                yield return new WaitForSeconds(2);

                speedLimit.SetActive(false);
                speedLimit.GetComponent<Animation>().Stop();

                if (speedExeed)
                {
                    Score -= 10;
                    scoreMinus.SetActive(true);
                    yield return new WaitForSeconds(1);
                    scoreMinus.SetActive(false);
                }
            }
            yield return null;
        }

    }
}