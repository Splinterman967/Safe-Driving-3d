using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class CarDrive : MonoBehaviour
{
    public int Score;
    private int Limit;
    private string anne;
    private string alertText;

    public float speedZed;
    public float speed;
    public float turnSpeed;
    public float gravityMultiplier;

    public bool speedExeed;
    public bool isCrossed;
    public bool isSpeedLimited;
    public bool isKarsýSerit;
    public bool isHitted;


    public GameObject speedLimit;
    public GameObject dontCross;
    public GameObject scoreMinus;
    public GameObject scorePlus;
    public GameObject trafficSign;
    public GameObject minSpeedSign;


    public TextMeshProUGUI speedText;
    public TextMeshProUGUI scoreText;

    public Rigidbody rb;
    private bool minSpeed;


    void Start()
    {
       
        Limit = 100;
        isCrossed = false;
        isSpeedLimited = false;
        speedExeed = false;
        Score = 100;
        minSpeed = true;

        string alertText = speedLimit.GetComponent<TextMeshProUGUI>().text.ToString();

        StartCoroutine(checkIfCroessed());
        StartCoroutine(checkSpeedLimit());
        StartCoroutine(checkCarLocation());
        StartCoroutine(checkMinSpeed());
        StartCoroutine(minSpeedSignTime());
    }

    
    private void Update()
    {
        speedLimit.GetComponent<TextMeshProUGUI>().SetText(alertText);

        
        increaseScorByTime();
        checkTrafficSign();
        checkCarLocation();
        speedLimiter();
        

    }

    

    void FixedUpdate()
    {

        carMovement();
        speedMeter();
    }

   
    void checkTrafficSign()
    {
        if (trafficSign.GetComponent<Image>().sprite.name == "50 limit")
        {
            Limit = 50;
        }
        else if (trafficSign.GetComponent<Image>().sprite.name == "70 limit")
        {
            Limit = 70;
        }
        else 
        {
            Limit = 100;
        }



        if (speedZed > Limit)
        {
            speedExeed = true;
        }
        else
        {
            speedExeed = false;
        }
        if (speedZed > 20)
        {
            minSpeed = false;
        }
        else
        {
            minSpeed = true;
        }



        //Karsý serite gecýp gecmedýgýný kontrol edýyo
        float carLocationX = gameObject.transform.position.x;

        if (carLocationX < 0)
        {
            isKarsýSerit = true;
        }
        else
        {
            isKarsýSerit = false;
        }


    }


    IEnumerator checkSpeedLimit()
    {

        while (true)
        {
            if (speedExeed)
            {
                alertText = "Slow Down!";
                speedLimit.SetActive(true);
                speedLimit.GetComponent<Animation>().Play();


                yield return new WaitForSeconds(2);

                speedLimit.SetActive(false);
                speedLimit.GetComponent<Animation>().Stop();

                //2 sn boyunca speedi asmýssa
                if (speedExeed)
                {
                    Score -= 10;
                    scoreMinus.SetActive(true);
                    yield return new WaitForSeconds(1);
                    scoreMinus.SetActive(false);
                }

                //Speedi astýktan hemen sonra akýllanmýssa
                else
                {
                    Score += 10;
                    scorePlus.SetActive(true);
                    yield return new WaitForSeconds(1);
                    scorePlus.SetActive(false);

                }
            }

            //Speedi hic asmamýssa
            else
            {
                yield return new WaitForSeconds(7);
                Score += 10;
                scorePlus.SetActive(true);
                yield return new WaitForSeconds(1);
                scorePlus.SetActive(false);
            }

            yield return null;
        }

    }

    IEnumerator checkMinSpeed()
    {
        while (true)
        {
            if (minSpeed)
            {

                yield return new WaitForSeconds(5);
                if (minSpeed)
                {
                    Score -= 10;
                    scoreMinus.SetActive(true);
                    yield return new WaitForSeconds(1);
                    scoreMinus.SetActive(false);
                }


                //else
                //{
                //    Score += 10;
                //    scorePlus.SetActive(true);
                //    yield return new WaitForSeconds(1);
                //    scorePlus.SetActive(false);

                //}


            }
            yield return null;
        }
    }

    IEnumerator minSpeedSignTime()
    {
        while (true)
        {
            if (minSpeed)
            {
                minSpeedSign.SetActive(true);
                minSpeedSign.GetComponent<Animation>().Play();
            }
            else
            {
                minSpeedSign.SetActive(false);
                minSpeedSign.GetComponent<Animation>().Stop();
            }
            yield return null;
        }
    }



    IEnumerator checkCarLocation()
    {

        while (true)
        {
            if (isKarsýSerit)
            {
                
                speedLimit.SetActive(true);
                alertText = "Dont Cross Opposite Line!";
                speedLimit.GetComponent<Animation>().Play();


                yield return new WaitForSeconds(2);

                speedLimit.SetActive(false);
                speedLimit.GetComponent<Animation>().Stop();

                if (isKarsýSerit)
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



    void speedLimiter()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpeedLimited = true;
            anne = speedText.text.ToString().Substring(7, (speedText.text.ToString().Length - 7));
            


        }
        else if (Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.S))
        {
            isSpeedLimited = false;

        }
        if (isSpeedLimited)
        {
            //rb.velocity.Set(rb.velocity.x, rb.velocity.y, System.Convert.ToInt32(anne));
            Vector3 baba = new Vector3(rb.velocity.x, rb.velocity.y, System.Convert.ToInt32(anne));
            rb.AddForce(baba - rb.velocity, ForceMode.VelocityChange);
        }
    }


    void carMovement()
    {


        if (Input.GetKey(KeyCode.W)||isSpeedLimited)
        {
            if (!isSpeedLimited)
            {

                Vector3 forceToAdd = transform.forward;
                forceToAdd.y = 0;
                rb.AddForce(forceToAdd * speed * 10);
            }


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

            if (!isSpeedLimited)
            {
                Vector3 forceToAdd = -transform.forward;
                forceToAdd.y = 0;
                rb.AddForce(forceToAdd * speed * 10);
            }


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


        if (!isSpeedLimited)
        {

            rb.velocity = new Vector3(transform.TransformDirection(locVel).x, rb.velocity.y, transform.TransformDirection(locVel).z);

        }
        else
        {
            // rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }



        rb.AddForce(Vector3.down * gravityMultiplier * 10);
    }

    private void OnTriggerEnter(Collider collision)
    {


        if (trafficSign.GetComponent<Image>().sprite.name == "no overtaking")
        {
            if (collision.CompareTag("Npcar"))
            {

                
                isCrossed = true;
                StartCoroutine(checkIfCroessed());
            }

            //if (!collision.CompareTag("Npcar"))
            //{

              
            //    isCrossed = false;
            //    StartCoroutine(checkIfCroessed());
            //}
        }

        if (collision.CompareTag("hit"))
        {
            
            alertText = "baba düzgün sür";
        }
    }

    private void OnTriggerExit(Collider collision)
    {


        if (trafficSign.GetComponent<Image>().sprite.name == "no overtaking")
        {
            if (collision.CompareTag("Npcar"))
            {

                
                isCrossed = false;
                
            }
        }

    }

    
 






        IEnumerator checkIfCroessed()
    {

        while (true)
        {
            if (isCrossed)
            {

                dontCross.SetActive(true);

                yield return new WaitForSeconds(2);

                dontCross.SetActive(false);
               

                if (isCrossed)
                {
                    Score -= 10;
                    scoreMinus.SetActive(true);
                    yield return new WaitForSeconds(1);
                    scoreMinus.SetActive(false);
                }
                yield return null;
            }
            yield return null;
        }

    }
}