using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcar : MonoBehaviour

{

    public Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionX| RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 forceToAdd = transform.forward;
        forceToAdd.y = 0;
        rb.AddForce(forceToAdd * speed * 10);

        Vector3 locVel = transform.InverseTransformDirection(rb.velocity);
        locVel = new Vector3(0, locVel.y, locVel.z);
        rb.velocity = new Vector3(transform.TransformDirection(locVel).x, rb.velocity.y, transform.TransformDirection(locVel).z);
        
        rb.AddForce(Vector3.down * 2 * 10);

        if (rb.velocity.z >= 50)
        {
            rb.velocity = new Vector3(transform.TransformDirection(locVel).x, rb.velocity.y,
           50);
        }
        if (rb.velocity.z <= -70)
        {
            rb.velocity = new Vector3(transform.TransformDirection(locVel).x, rb.velocity.y,
           -70);
        }

    }
}