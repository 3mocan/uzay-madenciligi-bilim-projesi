using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot_UI_Demir : MonoBehaviour
{
    
    public int demirSayi = 0;
    public TMP_Text demirSayii;
    public GameObject toplamaDemir;



    void Awake()
    {
        
    }
    void Update()
    {
        demirSayii.text = demirSayi.ToString();
    }
}
