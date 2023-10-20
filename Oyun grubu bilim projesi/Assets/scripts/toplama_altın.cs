using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class toplama_altın : MonoBehaviour
{

    public GameObject skorr;
    public GameObject toplamaAltınn;
    public TMP_Text madenCanYazi;
    public GameObject maden;
    public GameObject Ayazi;
    public GameObject textMaden;
    public GameObject upgrade;
    public GameObject Player;

    Upgrades upgrades;
    Slot_UI_Altin altınTane;
    Skor skor;
    hareket harek;

    int a = 0;

    public int madenCan;

    public void Start()
    {
        harek = Player.GetComponent<hareket>();
        upgrades = upgrade.GetComponent<Upgrades>();
        altınTane = toplamaAltınn.GetComponent<Slot_UI_Altin>();
        skor = skorr.GetComponent<Skor>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Ayazi.SetActive(true);
            a += 10;
            textMaden.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Ayazi.SetActive(false);
            a -= 10;
            textMaden.SetActive(false);
        }
    }

    private void Update()
    {
        madenCanYazi.text = madenCan.ToString();
        if (madenCan <= 0)
        {
            altınTane.altinSayi += upgrades.eklemeUpgrade;
            Destroy(maden);
            Destroy(Ayazi);
            skor.CurrentSkor += upgrades.skorUpgrade;

        }

        if (a == 10 && Input.GetKeyDown(KeyCode.E))
        {
            
            madenCan -= upgrades.KırmaUpgrade;
            Debug.Log("pipi");
            harek.animator.SetTrigger("isMine");
        }
    }
}
