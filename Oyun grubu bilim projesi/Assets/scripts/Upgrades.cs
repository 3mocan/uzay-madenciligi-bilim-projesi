using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public GameObject Player;
    public GameObject Ametist;
    public GameObject Elmas;
    public GameObject Titanyum;
    public GameObject Altýn;
    public GameObject Demir;
    public int kirmaArt = 0;
    public int eklemeArt = 0;
    public int MaliyetKýrma = 50;
    public int MaliyetEkleme = 50;
    public int MaliyetHýz = 30;
    public TMP_Text MaliyetyaziKýrma;
    public TMP_Text MaliyetyaziEkleme;
    public TMP_Text MaliyetyaziHýz;
    public TMP_Text MaliyetCan;
    public TMP_Text MaliyetMaxCan;
    public TMP_Text MaliyetSkorr;
    public TMP_Text MaliyetMayýnn;

    public GameObject eklemebutton;
    public GameObject EklemeUpgradee;

    public int skorUpgrade = 10;
    public int eklemeUpgrade = 10;
    public int KýrmaUpgrade = 25;
    public int CanMaliyet = 25;
    public int MaliyetMayýn = 150;
    public int MaxCanMaliyet = 30;
    public int MaliyetSkor = 20;
    public int mayýnDetect = 0;

    Slot_UI_Elmas ToplamaElmas;
    Slot_UI_Demir ToplamaDemir;
    Slot_UI_Titanyum ToplamaTitanyum;
    Slot_UI_Altin ToplamaAltýn;
    Slot_UI_Ametist ToplamaAmetist;
    hareket Hareket;
    MayýnScript mayýnScript;


    public void Start()
    {
        ToplamaElmas = Elmas.GetComponent<Slot_UI_Elmas>();
        ToplamaAltýn = Altýn.GetComponent<Slot_UI_Altin>();
        ToplamaDemir = Demir.GetComponent<Slot_UI_Demir>();
        ToplamaTitanyum = Titanyum.GetComponent<Slot_UI_Titanyum>();
        ToplamaAmetist = Ametist.GetComponent<Slot_UI_Ametist>();
        Hareket = Player.GetComponent<hareket>();
    }

    public void kýrmaArttýr()
    {
       if(MaliyetKýrma <= ToplamaElmas.elmasSayi)
       {
            kirmaArt += 1;
            ToplamaElmas.elmasSayi -= MaliyetKýrma;
            MaliyetKýrma *= 3;
           
       }
    }

    public void EklemeArttýr()
    {
        if(MaliyetEkleme <= ToplamaAltýn.altinSayi)
        {
            eklemeArt += 1;
            ToplamaAltýn.altinSayi -= MaliyetEkleme;
            MaliyetEkleme *= 2;
        }

    }

    public void HýzArttýr()
    {
        if (MaliyetHýz <= ToplamaDemir.demirSayi)
        {
            ToplamaDemir.demirSayi -= MaliyetHýz;
            MaliyetHýz *= 2;
            Hareket.runSpeed += 2;
        }
    }
    
    public void CanArttýr()
    {
       if(Hareket.currentHealth <= 90 && ToplamaDemir.demirSayi >= CanMaliyet)
       {
            Hareket.currentHealth += 20;
            ToplamaDemir.demirSayi -= CanMaliyet;
       }

    }
        
    public void MaxCanArt()
    {
        if (ToplamaTitanyum.titanyumSayi >= MaxCanMaliyet)
        {
            Hareket.maxHealth += 10;
            ToplamaTitanyum.titanyumSayi -= MaxCanMaliyet;
            MaxCanMaliyet *= 2;
        }
    }
    public void SkorArt()
    {
        if (ToplamaAmetist.ametistSayi >= MaliyetSkor)
        {
            ToplamaAmetist.ametistSayi -= MaliyetSkor;
            skorUpgrade *= 2;
            MaliyetSkor *= 2;
        }


    }


    public void MayýnDetect()
    {
        if (ToplamaAmetist.ametistSayi >= MaliyetMayýn)
        {
            mayýnDetect = 1;
            ToplamaAmetist.ametistSayi -= MaliyetMayýn;

        }
    }




        
    
    public void Update()
    {
        MaliyetyaziKýrma.text = "Madenleri daha hizli kazmana yarar Maliyeti: " + MaliyetKýrma.ToString() + " Elmas";
        MaliyetyaziEkleme.text = "Her kýrdýðýn madenden daha fazla maden çýkar Maliyeti:" + MaliyetEkleme.ToString() + " Altýn";
        MaliyetyaziHýz.text = "Karakterin daha hýzlý hareket eder. Maliyeti:" + MaliyetHýz.ToString() + " Demir";
        MaliyetCan.text = "+20 Can -   Demir Maliyet:" + CanMaliyet.ToString();
        MaliyetMaxCan.text = "Maksimum Caný 10 arttýrýr. Maliyeti:" + MaxCanMaliyet.ToString() + "Titanyum";
        MaliyetSkorr.text = "Kazandýðýn skoru 2 kat arttýrýr. Maliyeti:" + MaliyetSkor.ToString() + "Ametist";
        MaliyetMayýnn.text = "Mayýnlarý belirli bir alanda görmeni saðlar. Maliyeti; " + MaliyetMayýn.ToString() + "Ametist";

        if (kirmaArt == 1)
        {
            KýrmaUpgrade = 34;
        }
        else if(kirmaArt == 2)
        {
            KýrmaUpgrade = 50;
        }
        else if (kirmaArt == 3)
        {
            KýrmaUpgrade = 75;
        }
        else if (kirmaArt == 4)
        {
            KýrmaUpgrade = 100;
        }




        if (eklemeArt == 1)
        {
            eklemeUpgrade = 20;
        }
        else if(eklemeArt == 2)
        {
            eklemeUpgrade = 40;
        }
        else if (eklemeArt == 3)
        {
            eklemeUpgrade = 60;
        }
        else if (eklemeArt == 4)
        {
            eklemeUpgrade = 100;
        }
        else if (eklemeArt == 5)
        {
            eklemeUpgrade = 120;
        }
        else if (eklemeArt == 6)
        {
            eklemeUpgrade = 150;
        }
        else if (eklemeArt == 7)
        {
            eklemeUpgrade = 175;
        }
        else if (eklemeArt == 8)
        {
            eklemeUpgrade = 200;
        }
        else if (eklemeArt == 9)
        {
            eklemeUpgrade = 225;
        }
        else if (eklemeArt == 10)
        {
            eklemeUpgrade = 250;
            MaliyetyaziEkleme.text = "Bu geliþtirmeyi sonuna kadar actiniz";
            eklemebutton.SetActive(false);
        }




    }
}
