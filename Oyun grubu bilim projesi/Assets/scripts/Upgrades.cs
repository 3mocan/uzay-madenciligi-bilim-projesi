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
    public GameObject Alt�n;
    public GameObject Demir;
    public int kirmaArt = 0;
    public int eklemeArt = 0;
    public int MaliyetK�rma = 50;
    public int MaliyetEkleme = 50;
    public int MaliyetH�z = 30;
    public TMP_Text MaliyetyaziK�rma;
    public TMP_Text MaliyetyaziEkleme;
    public TMP_Text MaliyetyaziH�z;
    public TMP_Text MaliyetCan;
    public TMP_Text MaliyetMaxCan;
    public TMP_Text MaliyetSkorr;
    public TMP_Text MaliyetMay�nn;

    public GameObject eklemebutton;
    public GameObject EklemeUpgradee;

    public int skorUpgrade = 10;
    public int eklemeUpgrade = 10;
    public int K�rmaUpgrade = 25;
    public int CanMaliyet = 25;
    public int MaliyetMay�n = 150;
    public int MaxCanMaliyet = 30;
    public int MaliyetSkor = 20;
    public int may�nDetect = 0;

    Slot_UI_Elmas ToplamaElmas;
    Slot_UI_Demir ToplamaDemir;
    Slot_UI_Titanyum ToplamaTitanyum;
    Slot_UI_Altin ToplamaAlt�n;
    Slot_UI_Ametist ToplamaAmetist;
    hareket Hareket;
    May�nScript may�nScript;


    public void Start()
    {
        ToplamaElmas = Elmas.GetComponent<Slot_UI_Elmas>();
        ToplamaAlt�n = Alt�n.GetComponent<Slot_UI_Altin>();
        ToplamaDemir = Demir.GetComponent<Slot_UI_Demir>();
        ToplamaTitanyum = Titanyum.GetComponent<Slot_UI_Titanyum>();
        ToplamaAmetist = Ametist.GetComponent<Slot_UI_Ametist>();
        Hareket = Player.GetComponent<hareket>();
    }

    public void k�rmaArtt�r()
    {
       if(MaliyetK�rma <= ToplamaElmas.elmasSayi)
       {
            kirmaArt += 1;
            ToplamaElmas.elmasSayi -= MaliyetK�rma;
            MaliyetK�rma *= 3;
           
       }
    }

    public void EklemeArtt�r()
    {
        if(MaliyetEkleme <= ToplamaAlt�n.altinSayi)
        {
            eklemeArt += 1;
            ToplamaAlt�n.altinSayi -= MaliyetEkleme;
            MaliyetEkleme *= 2;
        }

    }

    public void H�zArtt�r()
    {
        if (MaliyetH�z <= ToplamaDemir.demirSayi)
        {
            ToplamaDemir.demirSayi -= MaliyetH�z;
            MaliyetH�z *= 2;
            Hareket.runSpeed += 2;
        }
    }
    
    public void CanArtt�r()
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


    public void May�nDetect()
    {
        if (ToplamaAmetist.ametistSayi >= MaliyetMay�n)
        {
            may�nDetect = 1;
            ToplamaAmetist.ametistSayi -= MaliyetMay�n;

        }
    }




        
    
    public void Update()
    {
        MaliyetyaziK�rma.text = "Madenleri daha hizli kazmana yarar Maliyeti: " + MaliyetK�rma.ToString() + " Elmas";
        MaliyetyaziEkleme.text = "Her k�rd���n madenden daha fazla maden ��kar Maliyeti:" + MaliyetEkleme.ToString() + " Alt�n";
        MaliyetyaziH�z.text = "Karakterin daha h�zl� hareket eder. Maliyeti:" + MaliyetH�z.ToString() + " Demir";
        MaliyetCan.text = "+20 Can -   Demir Maliyet:" + CanMaliyet.ToString();
        MaliyetMaxCan.text = "Maksimum Can� 10 artt�r�r. Maliyeti:" + MaxCanMaliyet.ToString() + "Titanyum";
        MaliyetSkorr.text = "Kazand���n skoru 2 kat artt�r�r. Maliyeti:" + MaliyetSkor.ToString() + "Ametist";
        MaliyetMay�nn.text = "May�nlar� belirli bir alanda g�rmeni sa�lar. Maliyeti; " + MaliyetMay�n.ToString() + "Ametist";

        if (kirmaArt == 1)
        {
            K�rmaUpgrade = 34;
        }
        else if(kirmaArt == 2)
        {
            K�rmaUpgrade = 50;
        }
        else if (kirmaArt == 3)
        {
            K�rmaUpgrade = 75;
        }
        else if (kirmaArt == 4)
        {
            K�rmaUpgrade = 100;
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
            MaliyetyaziEkleme.text = "Bu geli�tirmeyi sonuna kadar actiniz";
            eklemebutton.SetActive(false);
        }




    }
}
