using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public GameObject Npcar;
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
            GameObject carObject = Instantiate(Npcar, location);
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
