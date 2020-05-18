using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche1 : MovingObject
{
    public int playerDamage;
    public Sprite goizquierda;
    public Sprite goderecha;
    public Sprite goarriba;
    public Sprite goabajo;

    private SpriteRenderer spriterenderer;
    int move = 0;

    //necesto un variable que me guarde la posicion del enemigo y me lo pasa el boardManager


    protected override void Awake()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        base.Awake();
    }

    protected override void Start()
    { /*
        GameManager.instance.AddEnemyToList(this);
        target = GameObject.FindGameObjectWithTag("Player").transform;*/
        moveTime = 0.05f;
        base.Start();
    }

    protected override void AttemptMove(string objectname, int xDir, int yDir)
    {
        base.AttemptMove(objectname, xDir, yDir);

    }

    void Update()
    {
        if (!moving)
        {
            if (move == 0)
                AttemptMove("coche", 1, 0);
            

            else if (move == 1)
                AttemptMove("coche", 0, 1);
            
            else if (move == 2)
                AttemptMove("coche", -1, 0);
            
            else
                AttemptMove("coche", 0, -1);
        }

        Comprobarposicion();
    }
    private void Comprobarposicion()
    {
        if (transform.position.x == -6f && transform.position.y == -30f)
        {
            move = 1;
            spriterenderer.sprite = goarriba;
        }

        else if (transform.position.x == -6 && transform.position.y == -19)
        {
            move = 2;
            spriterenderer.sprite = goizquierda;
        }
        else if (transform.position.x == -29 && transform.position.y == -19)
        {
            move = 3;
            spriterenderer.sprite = goabajo;
        }
        else if (transform.position.x == -29 && transform.position.y == -30)
        {
            move = 0;
            spriterenderer.sprite = goderecha;
        }
    }

    protected override void OnCantMove(GameObject go)
    {
        moving = false;
        /*Player hitPlayer = go.GetComponent<Player>();

        if (hitPlayer != null)
        {
            hitPlayer.LoseHealth(playerDamage);
        }


        if (transform.position.x < go.transform.position.x)
        {
            
            move = 1;

        }
        else if (transform.position.x > go.transform.position.x)
        {
            
            move = 0;
        }*/

    }
}
