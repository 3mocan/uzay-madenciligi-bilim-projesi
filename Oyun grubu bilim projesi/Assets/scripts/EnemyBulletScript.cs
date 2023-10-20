using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameObject gameObjectt;
    public GameObject skor;
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private float timer;

    public int canAzalt;

    hareket Can;
    Skor skorr;

    void Start()
    {
        skorr = skor.GetComponent<Skor>();
        canAzalt = 20;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Can = player.GetComponent<hareket>();

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot + 90);
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
        
        if(skorr.CurrentSkor >= 500)
        {
            canAzalt = 35;
            force += 4;
        }
        if (skorr.CurrentSkor >= 1000)
        {
            canAzalt = 50;
            force += 6;
        }
        if (skorr.CurrentSkor >= 1500)
        {
            canAzalt = 60;
            force += 8;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Can.currentHealth -= canAzalt;
            Destroy(gameObject);
            Can.animator.SetTrigger("isHurt");
        }
    }


}
