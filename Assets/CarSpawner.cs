using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public GameObject car;
    public Transform location;
    public Transform location2;
    public float speed = 5;


    void Start()
    {

        StartCoroutine(carSpawner());
    }

    IEnumerator carSpawner()
    {

        while (true)
        {
            yield return new WaitForSeconds(3);
            GameObject carObject = Instantiate(car, location);

            //carObject.GetComponent<Rigidbody>().velocity = new Vector3(0.20f, 0.02f, 50f);
            //MoveObject(carObject.GetComponent<Rigidbody>());



            // GameObject carObject2 = Instantiate(car, location2);

           // location.position = new Vector3(location.position.x, location.position.y, location.position.z + 100);
        }

    }



    void FixedUpdate()
    {
        // MoveObject();
    }

    void MoveObject(Rigidbody rb)
    {
        // Calculate the desired velocity based on the constant speed
        Vector3 desiredVelocity = transform.forward * speed;

        // Set the Rigidbody's velocity to the desired velocity
        rb.velocity = desiredVelocity;
    }



}