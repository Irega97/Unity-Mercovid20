using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    bool llave = false;
    bool animacion = false;
    public GameObject llaveobject;
    private Vector2 touchOrigin = -Vector2.one;
    private Animator animator;
    public int health; //puntos de vida 
    public bool contagiado = false;
    public bool guardiahablado;


    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        base.Awake();
    }

    protected override void Start()
    {
        health = GameManager.instance.healthPoints;
        contagiado = GameManager.instance.contagio;
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

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        horizontal = (int)Input.GetAxisRaw("Horizontal"); //-1 si es la izquierda, 1 si es derecha, 0 si no pulsa ninguna tecla
        vertical = (int)Input.GetAxisRaw("Vertical"); //-1 si abajo, 1 si arriba y 0 si no pulsamos


            if (horizontal != 0) vertical = 0;

            else if (vertical != 0) horizontal = 0;
#else
        /*if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }
            else if(myTouch.phase == TouchPhase.Ended && touchOrigin !=-Vector2.one)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                if (x!= 0 || y != 0)
                {
                    countr = 20;
                    countl = 20;
                    countb = 20;
                    countf = 20;
                    if (Mathf.Abs(x) >= Mathf.Abs(y))
                    {
                        horizontal = x > 0 ? 1 : -1;
                    }

                    else
                    {
                        vertical = y > 0 ? 1 : -1;
                    }
                }
            }
        }*/
#endif

        if (!moving && !animacion)
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

    IEnumerator esperar()
    {
        yield return new WaitForSeconds(1);
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(0, 1);
        StartCoroutine(SmoothMovement(end));
    }
    protected override void OnCantMove(GameObject go)
    {
        if (go.tag == "PuertaMercadona" && llave)
        {
            animacion = true;
            Animator animacionpuerta = go.GetComponent<Animator>();
            animacionpuerta.SetTrigger("AbrirMercadona");
            StartCoroutine(esperar());
        }

        if (go.tag == "GuardiaLlave")
            guardiahablado = true;
            

        if (go.tag == "PropietarioMercadona" && GameObject.Find("Llave(Clone)") == null && !llave && guardiahablado)
                llaveobject = Instantiate(llaveobject, new Vector3(51, 31, 0f), Quaternion.identity);

        if (go.tag == "Llave")
        {
            llave = true;
            Destroy(GameObject.Find("Llave(Clone)"));
        }
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
        contagiado = true;
        StartCoroutine(Contagio(5));
        CheckIfGameOver();
        Debug.Log(health);

    }

   IEnumerator Contagio(int perdida)
    {

        while(contagiado)
        {
            if (health > 0)
                health = health - perdida;

            else
                health = 0;

            CheckIfGameOver();
            Debug.Log(health);
            perdida++;
            yield return new WaitForSeconds(1);
        }
        
    }
}
