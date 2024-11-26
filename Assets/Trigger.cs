using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject Wall;//ref:25204:

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Destroy(Wall);
            Destroy(gameObject);//ref:-2126:
        }
    }
    
        
    



}
