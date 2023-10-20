using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class toplama_ametist : MonoBehaviour
{
    public GameObject skorr;
    public GameObject toplamaAmetistt;
    public TMP_Text madenCanYazi;
    public GameObject maden;
    public GameObject Amyazi;
    public GameObject textMaden;
    public GameObject upgrade;
    public GameObject Player;

    Upgrades upgrades;
    Slot_UI_Ametist ametistTane;
    Skor skor;
    hareket harek;

    int a = 0;


    public int madenCan;

    public void Start()
    {
        harek = Player.GetComponent<hareket>();
        upgrades = upgrade.GetComponent<Upgrades>();
        ametistTane = toplamaAmetistt.GetComponent<Slot_UI_Ametist>();
        skor = skorr.GetComponent<Skor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Amyazi.SetActive(true);
            a += 10;
            textMaden.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Amyazi.SetActive(false);
            a -= 10;
            textMaden.SetActive(false);
        }
    }

    private void Update()
    {
        madenCanYazi.text = madenCan.ToString();
        if (madenCan <= 0)
        {
            ametistTane.ametistSayi += upgrades.eklemeUpgrade;
            Destroy(maden);
            Destroy(Amyazi);
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
