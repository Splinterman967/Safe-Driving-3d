using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficSigns : MonoBehaviour
{
    public List<Sprite> trafficSigns;
    public GameObject trafficSign;
    int i;
   
    void Start()
    {
       
       
        i = 0;
        StartCoroutine(changeTrafficSign());
    }

    
    void Update()
    {
        
    }

    IEnumerator changeTrafficSign()
    {
    
        while (true)
        {
           
            trafficSign.GetComponent<Image>().sprite = trafficSigns[i%3];
            yield return new WaitForSeconds(7);
            i++;
            
                
        }
    }
}
