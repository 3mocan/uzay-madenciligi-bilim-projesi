using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot_UI_Titanyum : MonoBehaviour
{
    
    public int titanyumSayi = 0;
    public TMP_Text titanyumSayii;
    public GameObject toplamaTitanyum;



    void Awake()
    {
       
    }
    void Update()
    {
        titanyumSayii.text = titanyumSayi.ToString();
    }
}
