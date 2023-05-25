using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toplanabilir : MonoBehaviour
{
    public ToplanabilirTipi tipi;
    
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        hareket player = Collision.GetComponent<hareket>();

        if (player)
        {
            player.inventory.Add(tipi);
            Destroy(this.gameObject);
        }
            

    }
}

public enum ToplanabilirTipi
{
    NONE, DIAMOND,
}