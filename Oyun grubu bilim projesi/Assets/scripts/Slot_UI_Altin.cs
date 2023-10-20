using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot_UI_Altin : MonoBehaviour
{
    
    public int altinSayi = 0;
    public TMP_Text altinSayii;
    public GameObject toplamaAltýn;



    void Awake()
    {
       
    }
    void Update()
    {
        altinSayii.text = altinSayi.ToString();
    }
}
