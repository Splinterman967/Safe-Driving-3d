using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public GameObject[] Npcars;
    public Transform location;
    public Transform location2;
    public Transform location3;
    public Transform location4;
    public float speed = 5;
    


    void Start()
    {

        StartCoroutine(carSpawner());
    }

    IEnumerator carSpawner()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 4));
            GameObject carObject =Instantiate(Npcars[Random.Range(0,4)],location);
            yield return new WaitForSeconds(Random.Range(1, 4));
            GameObject carObject2 = Instantiate(Npcars[Random.Range(0, 4)], location2);
            yield return new WaitForSeconds(Random.Range(1, 4));
            GameObject carObject3 = Instantiate(Npcars[Random.Range(0, 4)], location3);
            yield return new WaitForSeconds(Random.Range(1, 4));
            GameObject carObject4 = Instantiate(Npcars[Random.Range(0, 4)], location4);
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
       
    }
}