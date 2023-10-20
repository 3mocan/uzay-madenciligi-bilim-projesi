using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    hareket Hareket;
    WalkerGenerator enemyspawn;
    
    public Transform Player;
    public GameObject Playerr;
    public GameObject spawn;
    private GameObject instantiatedObj;
    public float movespeed = 2.5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public int al = 0;
    public Animator animator;
    public int currentHealth = 100;
    public static int caniyok = 1;

    void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        Hareket = Playerr.GetComponent<hareket>();
        enemyspawn = spawn.GetComponent<WalkerGenerator>();
    }
 
    void Update()
    {
        Vector2 direction = Player.position - transform.position;    
        direction.Normalize();
        movement = direction;
        animator.SetFloat("Speed", movement.magnitude);
        if (Hareket.DetectBoom == 1)
        {
            Hareket.DetectBoom -= 1;
            currentHealth -= 100;
        }
        if (currentHealth==0)
        {
            caniyok = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            al++;
        }     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            al--;
        }
    }


    public void FixedUpdate()
    {
        if (al == 1)
        {
            movespeed = 2.5f;
           MoveCharacter(movement);          
        }
        else if (al == 0)
        {
            movespeed = 0;
        }

    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * movespeed * Time.deltaTime));
    }
}
