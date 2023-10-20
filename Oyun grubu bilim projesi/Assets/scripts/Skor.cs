using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Skor : MonoBehaviour
{
    public int skor;

    public GameObject DüþmanMermiAteþ;
    
    public TMP_Text CurrentScoreText;
    public TMP_Text skorText;
    public int HighScore;
    public int CurrentSkor;
    private int HighestScore;

    EnemyBulletScript Mermi;

    void Start()
    {
        CurrentSkor = 0;
        Mermi = DüþmanMermiAteþ.GetComponent<EnemyBulletScript>();
    }


   
    void Update()
    {
        skorText.text = "Skorun: " + CurrentSkor.ToString();

        CurrentScoreText.text = "Þu Anki Skorun: " + CurrentSkor.ToString();

        if (HighestScore < CurrentSkor)
        {
            HighestScore = CurrentSkor;
        }



       
      





    }
}
