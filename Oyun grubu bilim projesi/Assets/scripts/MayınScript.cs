using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayınScript : MonoBehaviour
{
    public GameObject player;
    public GameObject skor;
    public GameObject mayin;
    public GameObject upgrade;

    public int canAzalt;

    Upgrades upgrades;


    Renderer ren;
    

    Skor skorr;
    hareket Cann;


    private void Update()
    {
        if (skorr.CurrentSkor >= 500)
        {
            canAzalt = 45;
        }
        if (skorr.CurrentSkor >= 1000)
        {
            canAzalt = 60;
        }
    }




    void Start()
    {
        canAzalt = 30;
        Cann = player.GetComponent<hareket>();
        skorr = skor.GetComponent<Skor>();
        ren = GetComponent<Renderer>();
        ren.material.color = new Color(255, 255, 255, 0);
        upgrades = upgrade.GetComponent<Upgrades>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Cann.currentHealth -= canAzalt;
            Destroy(mayin);
            Cann.animator.SetTrigger("isHurt");
        }
        
        if(upgrades.mayınDetect == 1)
        {
            if (collision.gameObject.tag == "mineControl")
            {
                mayin.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mineControl")
        {
            mayin.GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);
        }
    }








}
