using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MovingObject
{

    public float restartLevelDelay = 1f;
    int countf = 0;
    int countb = 0;
    int countl = 0;
    int countr = 0;
    int tiempoupdate = 15;
    int estado;
    int horizontal;
    int vertical;


    private Animator animator;
    public int health; //puntos de vida 


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

    /*private void OnDisable()
    {
        GameManager.instance.healthPoints = health;
    }*/

    void CheckIfGameOver()
    {
        if (health <= 0) GameManager.instance.GameOver();
    }

    protected override void AttemptMove(string objectname, int xDir, int yDir)
    {
        base.AttemptMove(objectname, xDir, yDir);
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = (int)Input.GetAxisRaw("Horizontal"); //-1 si es la izquierda, 1 si es derecha, 0 si no pulsa ninguna tecla
        vertical = (int)Input.GetAxisRaw("Vertical"); //-1 si abajo, 1 si arriba y 0 si no pulsamos


            if (horizontal != 0) vertical = 0;
            else if (vertical != 0) horizontal = 0;

            if (!moving)
            {
                if (horizontal == 1)
                {
                    if (estado != 3)
                    {
                        estado = 3;
                        CambiarIdle(estado);
                    }

                    countr++;

                    if (countr >= tiempoupdate)

                    {
                        AttemptMove("player", horizontal, vertical);
                        animator.SetTrigger("rightMove");
                    }

                }

                else if (horizontal == -1)
                {
                    if (estado != 2)
                    {
                        estado = 2;
                        CambiarIdle(estado);
                    }

                    countl++;

                    if (countl >= tiempoupdate)

                    {
                        AttemptMove("player", horizontal, vertical);
                        animator.SetTrigger("leftMove");
                    }
                }

                else if (vertical == 1)
                {
                    if (estado != 0)
                    {
                        estado = 0;
                        CambiarIdle(estado);
                    }

                    countb++;

                    if (countb >= tiempoupdate)

                    {
                        AttemptMove("player", horizontal, vertical);
                        animator.SetTrigger("backMove");
                    }
                }

                else if (vertical == -1)
                {
                    if (estado != 1)
                    {
                        estado = 1;
                        CambiarIdle(estado);
                    }

                    countf++;

                    if (countf >= tiempoupdate)

                    {
                        AttemptMove("player", horizontal, vertical);
                        animator.SetTrigger("frontMove");
                    }
                }
            }


            if (horizontal == 0)
            {
                ResetEstados("x");
            }


            if (vertical == 0)
            {
                ResetEstados("y");
            }

    }

    public void ResetEstados(string dir)
    {
        if (dir == "x")
        {
            countl = 0;
            countr = 0;
        }

        else if (dir == "y")
        {
            countf = 0;
            countb = 0;
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
    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void LoseHealth(int loss)
    {
        health -= loss;
        CheckIfGameOver();
        Debug.Log(health);
    }
}
