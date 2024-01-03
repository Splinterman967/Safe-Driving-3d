using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public GameObject car;
    public Transform location;
    public Transform location2;

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

            GameObject carObject2 = Instantiate(car, location2);

            location.position = new Vector3(location.position.x, location.position.y, location.position.z + 30);
        }
      
    }
}
