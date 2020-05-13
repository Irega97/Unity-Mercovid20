using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoVertical : MovingObject
{
    public int playerDamage;

    private Animator animator;
    private Transform target;


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

    protected override void AttemptMove(string a, int xDir, int yDir)
    {
        base.AttemptMove(a, xDir, yDir);

    }

    private void Update()
    {
        
    }



    protected override void OnCantMove(GameObject go)
    {
        Player hitPlayer = go.GetComponent<Player>();

        if (hitPlayer != null)
        {
            hitPlayer.LoseHealth(playerDamage);
        }
    }

}
