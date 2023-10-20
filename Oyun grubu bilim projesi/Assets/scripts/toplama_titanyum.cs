using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class toplama_titanyum : MonoBehaviour
{

    public GameObject skorr;
    
    
    
    public int titanyumSayi = 0;
    public GameObject toplamaTitanyumm;
    public TMP_Text madenCanYazi;
    public GameObject maden;
    public GameObject Tyazi;
    public GameObject textMaden;
    public GameObject upgrade;
    public GameObject Player;

    Upgrades upgrades;
    Slot_UI_Titanyum titanyumTane;
    Skor skor;
    hareket harek;

    int a = 0;


    public int madenCan;

    public void Start()
    {
        harek = Player.GetComponent<hareket>();
        upgrades = upgrade.GetComponent<Upgrades>();
        titanyumTane = toplamaTitanyumm.GetComponent<Slot_UI_Titanyum>();
        skor = skorr.GetComponent<Skor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Tyazi.SetActive(true);
            a += 10;
            textMaden.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Tyazi.SetActive(false);
            a -= 10;
            textMaden.SetActive(false);
        }
    }

    private void Update()
    {
        madenCanYazi.text = madenCan.ToString();
        if (madenCan <= 0)
        {
            skor.CurrentSkor += upgrades.skorUpgrade;  //skorupgrade eklenecek
            titanyumTane.titanyumSayi += upgrades.eklemeUpgrade;
            Destroy(maden);
            Destroy(Tyazi);
        }

        if (a == 10 && Input.GetKeyDown(KeyCode.E))
        {
            madenCan -= upgrades.KýrmaUpgrade;
            Debug.Log("pipi");
            if(Player.transform.position.x > transform.position.x)
            {          
                //player saðýnda oluyor madenin

            }
            else if (Player.transform.position.x < transform.position.x)
            {
                //player solunda oluyor madenin

            }









        }



    }
}
