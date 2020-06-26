using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardia : MovingObject
{

    public int hormax;
    public int vermax;
    public int move;
    int horizontal;
    int vertical;
    public int contador;
    public int ordenmovimiento;
    private Animator animator;
    bool pillado = false;

    protected override void Start()
    {
        estadoGuardia();
        base.Start();
    }

    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        base.Awake();
    }

    void Update()
    {
        if (!moving && !pillado)
        {
            if (move == 0)
            {
                base.AttemptMove("guardia", 0, -1);
                animator.SetTrigger("rightMove");
                horizontal++;
            }

            else if (move == 1)
            {
                base.AttemptMove("guardia", 0, 1);
                animator.SetTrigger("backMove");
                vertical++;
            }

            else if (move == 2)
            {
                base.AttemptMove("guardia", -1, 0);
                animator.SetTrigger("leftMove");
                horizontal--;
            }

            else
            {
                base.AttemptMove("guardia", 1, 0);
                animator.SetTrigger("frontMove");
                vertical--;
            }

            ComprobarPosicion();
        }
    }


    private void estadoGuardia()
    {
        if (move == 0)
        {
            animator.SetBool("frontIdle", true);
            animator.SetBool("backIdle", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);
        }

        else if (move == 1)
        {
            animator.SetBool("frontIdle", false);
            animator.SetBool("backIdle", true);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", false);

        }
        else if (move == 2)
        {
            animator.SetBool("frontIdle", false);
            animator.SetBool("backIdle", false);
            animator.SetBool("leftIdle", true);
            animator.SetBool("rightIdle", false);

        }
        else if (move == 3)
        {
            animator.SetBool("frontIdle", false);
            animator.SetBool("backIdle", false);
            animator.SetBool("leftIdle", false);
            animator.SetBool("rightIdle", true);
        }
    }

    private void ComprobarPosicion()
    {
        if (horizontal == hormax)
        {
            if (ordenmovimiento == 0)
                move = 0;
            else
                move = 1;
        }

        else if (-horizontal == hormax)
        {
            if (ordenmovimiento == 0)
                move = 1;
            else
                move = 0;
        }

        else if (vertical == vermax){
            if (ordenmovimiento == 0)
                move = 3;
            else
                move = 2;
        }

        else
        {
            if (ordenmovimiento == 0)
                move = 2;
            else
                move = 3;
        }
    }

    protected override void OnCantMove(GameObject go)
    {

    }
}
