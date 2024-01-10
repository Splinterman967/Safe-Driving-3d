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
          
            yield return new WaitForSeconds(2);
            GameObject carObject2 = Instantiate(car, location2);
        }
        
    }

    //void changeColor()
    //{
    //    GameObject carObject = Instantiate(car, location);
    //    int i = 0;
    //    Color random = new Color(Random.Range(0, 150), Random.Range(0, 150), Random.Range(0, 150));
    //    while (i < 8)
    //    {
    //        Debug.Log(carObject.transform.GetChild(i).gameObject.GetComponent<Renderer>().materials[0]);
    //        carObject.transform.GetChild(i).gameObject.GetComponent<Renderer>().materials[0].color=random;
            
    //        i++;
            
    //    }
    //}


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