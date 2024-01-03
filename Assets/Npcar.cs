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
        Vector3 forceToAdd = transform.forward;
        forceToAdd.y = 0;
        rb.AddForce(forceToAdd * speed * 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
