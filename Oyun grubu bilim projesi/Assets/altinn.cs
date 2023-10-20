using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altinn : MonoBehaviour
{
    public GameObject altin;
   
    void Start()
    {

        Instantiate(altin, transform.position, Quaternion.identity);

    }

   
}
