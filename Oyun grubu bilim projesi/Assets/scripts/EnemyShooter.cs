using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletPos;

    private float timer;
    public GameObject Player;

    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        

        float distance = Vector2.Distance(transform.position, Player.transform.position);
        

        if (distance < 10)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                shoot();
            }

        }

       

    }
    void shoot()
    {
        Instantiate(Bullet, bulletPos.position, Quaternion.identity);

    }
    

}