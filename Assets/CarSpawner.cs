using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public GameObject car;
    public Transform location;

    void Start()
    {
        GameObject carObject = Instantiate(car, location);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
