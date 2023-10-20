using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot_UI_Ametist : MonoBehaviour
{
    public int ametistSayi = 0;


    public TMP_Text ametistSayii;
    public GameObject toplamaAmetist;



    void Awake()
    {

    }
    void Update()
    {
        ametistSayii.text = ametistSayi.ToString();
    }
}
