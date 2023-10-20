using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class toplama_elmas : MonoBehaviour
{
    public GameObject skorr;
    public GameObject toplamaElmass;
    public TMP_Text madenCanYazi;
    public GameObject maden;
    public GameObject Eyazi;
    public GameObject textMaden;
    public GameObject upgrade;
    public GameObject Player;

    Upgrades upgrades;
    Slot_UI_Elmas elmasTane;
    Skor skor;
    hareket harek;

    int a = 0;

   
    public int madenCan;

    public void Start()
    {
        harek = Player.GetComponent<hareket>();
        upgrades = upgrade.GetComponent<Upgrades>();
        elmasTane = toplamaElmass.GetComponent<Slot_UI_Elmas>();
        skor = skorr.GetComponent<Skor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Eyazi.SetActive(true);
            a += 10;
            textMaden.SetActive(true);
        }
           
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Eyazi.SetActive(false);
            a -= 10;
            textMaden.SetActive(false);
        }
    }

    private void Update()
    {
        madenCanYazi.text = madenCan.ToString();
        if (madenCan <= 0)
        {
            elmasTane.elmasSayi += upgrades.eklemeUpgrade;
            Destroy(maden);
            Destroy(Eyazi);
            skor.CurrentSkor += upgrades.skorUpgrade;
        }

        if (a == 10 && Input.GetKeyDown(KeyCode.E))
        {
           
            madenCan -= upgrades.KýrmaUpgrade;
            Debug.Log("pipi");
            harek.animator.SetTrigger("isMine");
        }
    }
    

}
