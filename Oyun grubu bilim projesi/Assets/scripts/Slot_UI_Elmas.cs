using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot_UI_Elmas : MonoBehaviour
{
    public int elmasSayi = 0;
    
    
    public TMP_Text elmasSayii;
    public GameObject toplamaElmas;
    


    void Awake()
    {
        
    }
    void Update()
    {
        elmasSayii.text = elmasSayi.ToString();  
    }
}
