using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmasSpawner : MonoBehaviour
{
    public GameObject maden;
    public GameObject madenPreFab;
    toplama_elmas ToplamaElmas;

    public void Start()
    {
        ToplamaElmas = maden.GetComponent<toplama_elmas>();

    }




    void Update()
    {
        if(ToplamaElmas.madenCan <= 0)
        {
            Debug.Log("fak");
            StartCoroutine(ElmasSpawn());
           
        }

    }

    public IEnumerator ElmasSpawn()
    {
        yield return new WaitForSeconds(5);
        Instantiate(madenPreFab, transform.position ,Quaternion.identity);
    }
}
