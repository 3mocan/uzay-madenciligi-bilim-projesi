using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomEnemyDie : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
        }
    }




}