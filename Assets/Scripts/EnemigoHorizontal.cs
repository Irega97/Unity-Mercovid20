using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoHorizontal : MovingObject
{
    public int playerDamage;

    private Animator animator;




    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        base.Awake();
    }

    protected override void Start()
    { /*
        GameManager.instance.AddEnemyToList(this);
        target = GameObject.FindGameObjectWithTag("Player").transform;*/
        base.Start();
    }

    protected override void AttemptMove(string objectname, int xDir, int yDir)
    {
        base.AttemptMove(objectname, xDir, yDir);

    }

    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;
        bool canMove = true;
        while (canMove)
        {
            AttemptMove("Enemigo", xDir++, yDir);
        }

    }


    protected override void OnCantMove(GameObject go)
    {

        Player hitPlayer = go.GetComponent<Player>();

        if (hitPlayer != null)
        {
            hitPlayer.LoseHealth(playerDamage);
        }

        /*if (transform.position.y<"posicion inicial")
        {
            animator.SetBool("TopeArriba", true);
            animator.SetBool("TopeAbajo", false);
        } else
        {
            animator.SetBool("TopeArriba", false);
            animator.SetBool("TopeAbajo", true);
        }*/

    }
}
