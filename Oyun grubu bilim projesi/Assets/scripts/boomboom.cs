using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomboom : MonoBehaviour
{
    public GameObject player;
    hareket Hareket;

    public void Start()
    {
        Hareket = player.GetComponent<hareket>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "boom")
        {
            Hareket.currentHealth -= 40;
            Hareket.DetectBoom += 1;         
        }
    }

  
}
