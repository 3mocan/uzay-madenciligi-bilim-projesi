using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class toplama_demir : MonoBehaviour
{
    public GameObject skorr;
    public GameObject toplamaDemirr;
    public TMP_Text madenCanYazi;
    public GameObject maden;
    public GameObject Dyazi;
    public GameObject textMaden;
    public GameObject upgrade;
    public GameObject Player;

    Upgrades upgrades;
    Slot_UI_Demir demirTane;
    Skor skor;
    hareket harek;

    int a = 0;


    public int madenCan;

    public void Start()
    {
        harek = Player.GetComponent<hareket>();
        upgrades = upgrade.GetComponent<Upgrades>();
        demirTane = toplamaDemirr.GetComponent<Slot_UI_Demir>();
        skor = skorr.GetComponent<Skor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Dyazi.SetActive(true);
            a += 10;
            textMaden.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Dyazi.SetActive(false);
            a -= 10;
            textMaden.SetActive(false);
        }
    }

    private void Update()
    {
        madenCanYazi.text = madenCan.ToString();
        if (madenCan <= 0)
        {
           
            demirTane.demirSayi += upgrades.eklemeUpgrade;
            Destroy(maden);
            Destroy(Dyazi);
            skor.CurrentSkor += upgrades.skorUpgrade;
        }

        if (a == 10 && Input.GetKeyDown(KeyCode.E))
        {
            
            madenCan -= upgrades.K�rmaUpgrade;
            Debug.Log("pipi");
            harek.animator.SetTrigger("isMine");
        }



    }
}