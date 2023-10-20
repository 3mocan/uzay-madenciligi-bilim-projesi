using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButonAnaMenü : MonoBehaviour
{


    public void OyunaGir()
    {
        SahneGir("Oyun");
    }
   
    
    public void SahneGir(string sahneisim)
    {
        SceneManager.LoadScene(sahneisim);
    }


    public void Çıkış()
    {
        Application.Quit();
    }
}
