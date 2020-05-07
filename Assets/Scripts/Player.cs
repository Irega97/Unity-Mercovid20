using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MovingObject
{

    public float restartLevelDelay = 1f;


    private Animator animator;
    private int health; //puntos de vida 


    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        base.Awake();
        
    }

    protected override void Start()
    {
        health = GameManager.instance.healthPoints;
        base.Start();
    }

    private void OnDisable()
    {
        GameManager.instance.healthPoints = health;
    }

    void CheckIfGameOver()
    {
        if (health <= 0) GameManager.instance.GameOver();
    }

    protected override void AttemptMove(int xDir, int yDir)
    {
        base.AttemptMove(xDir, yDir);
    }


    // Update is called once per frame
    void Update()
    {
        int estado = 0;
        int horizontal;
        int vertical;

        horizontal = (int)Input.GetAxisRaw("Horizontal"); //-1 si es la izquierda, 1 si es derecha, 0 si no pulsa ninguna tecla
        vertical = (int)Input.GetAxisRaw("Vertical"); //-1 si abajo, 1 si arriba y 0 si no pulsamos

        if (horizontal != 0) vertical = 0;
        if (vertical != 0) horizontal = 0;

        if (horizontal == 1)
        {
            estado = 3;
            CambiarIdle(estado);
            AttemptMove(horizontal, vertical);
            animator.SetTrigger("rightMove");


        } else if (horizontal == -1)
        {
            estado = 2;
            CambiarIdle(estado);
            AttemptMove(horizontal, vertical);
            animator.SetTrigger("leftMove");
        }else if (vertical == 1)
        {
            estado = 0;
            CambiarIdle(estado);
            AttemptMove(horizontal, vertical);
            animator.SetTrigger("backMove");
        }else if (vertical == -1)
        {
            estado = 1;
            CambiarIdle(estado);
            AttemptMove(horizontal, vertical);
            animator.SetTrigger("frontMove");
        }

    }

    public void CambiarIdle(int estado)
    {
        if ( estado == 0)
        {
            animator.SetBool("frontIdle", false);
            animator.SetBool("backIdle", true);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);

        } else if(estado == 1)
        {
            animator.SetBool("frontIdle", true);
            animator.SetBool("backIdle", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);

        }else if (estado == 2)
        {
            animator.SetBool("frontIdle", false);
            animator.SetBool("backIdle", false);
            animator.SetBool("leftIdle", true);
            animator.SetBool("rightIdle", false);

        } else if (estado == 3)
        {
            animator.SetBool("frontIdle", false);
            animator.SetBool("backIdle", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", true);

        }

    }

    protected override void OnCantMove(GameObject go)
    {
        //falta codigo
    }

  void Restart()
    {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseHealth(int loss)
    {
        health -= loss;
        CheckIfGameOver();
    }
}
