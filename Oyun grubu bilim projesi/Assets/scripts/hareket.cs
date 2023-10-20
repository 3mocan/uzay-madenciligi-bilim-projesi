using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hareket : MonoBehaviour
{
    Rigidbody2D body;

    public GameObject ölümEkraný;
    public GameObject ResumeButton;
    public Animator animator;


    float horizontal;
    float vertical;

    Vector2 movement;

    public float runSpeed = 6.0f;
    public int DetectBoom = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        ResumeButton.SetActive(true);
        //can
        currentHealth = maxHealth;
        //can
        body = GetComponent<Rigidbody2D>();
    }

    void Update()   
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);



        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(currentHealth <= 0)
        {
            ölümEkraný.SetActive(true);
            Pause();
        }
    }


    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * runSpeed * Time.deltaTime);   
    }
    //HAREKET
    //HAREKET
    //HAREKET
    //HAREKET
    //HAREKET

    public float currentHealth;
    public float maxHealth = 100;

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }


    public void AnaMenü()
    {
        SahneGir("Main Menu");
    }

    public void SahneGir(string sahneisim)
    {
        SceneManager.LoadScene(sahneisim);
    }

    public void MadenKaz()
    {
        animator.SetTrigger("isMine");
    }



    public void YenidenDene()
    {
        ölümEkraný.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
