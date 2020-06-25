using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    bool inter = false;
    bool llave = false;
    bool papel = false;

    bool animacion = false;
    public GameObject llaveobject;
    private Vector2 touchOrigin = -Vector2.one;
    private Animator animator;
    public int health; //puntos de vida 
    public bool contagiado = false;
    public Vector2 startPos;
    public Vector2 direction;


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
        inter = (bool)Input.GetKey(KeyCode.C);

#else
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.GetTouch(0);
            switch (myTouch.phase)
            {

                case TouchPhase.Began:
                    startPos = myTouch.position;
                    break;

                case TouchPhase.Moved:
                    direction = myTouch.position - startPos;
                    break;

                case TouchPhase.Ended:
                    direction.x = 0;
                    direction.y = 0;
                    horizontal = 0;
                    vertical = 0;
                    break;
            }

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    horizontal = 1;
                    countr = 20;
                }

                else
                {
                    horizontal = -1;
                    countl = 20;
                }
                    
            }

            else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            {
                if (direction.y > 0)
                {
                    vertical = 1;
                    countb = 20;
                }


                else
                {
                    vertical = -1;
                    countf = 20;
                }
                    
            }
        }
#endif

        if (horizontal != 0) vertical = 0;

        else if (vertical != 0) horizontal = 0;

        if (!moving && !animacion || GameManager.instance.doingSetup)
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


        if (inter)
        {
            if (estado == 0)
            {
                ComprovarDialogo(0, 1);
              
            } else if (estado == 1)
            {
                ComprovarDialogo(0, -1);
                
            } else if (estado == 2)
            {
                ComprovarDialogo(-1, 0);
            } else if (estado == 3)
            {
                ComprovarDialogo(1, 0);
            }

        }

    }

    private void ComprovarDialogo(int xDir, int yDir)
    {
        Vector2 final = new Vector2(transform.position.x + xDir, transform.position.y + yDir);
        RaycastHit2D hit = Physics2D.Linecast(transform.position, final, blockingLayer);

        if (hit.transform != null)
        {
            if (hit.transform.gameObject.tag == "GuardiaLlave" )
            {
                GameManager.instance.InteractuarEncargado(1);

                if (GameObject.Find("Llave(Clone)") == null && !llave)
                    llaveobject = Instantiate(llaveobject, new Vector3(51, 31, 0f), Quaternion.identity);
            }

            else if (hit.transform.gameObject.tag == "Llave")
            {
                llave = true;
                Destroy(GameObject.Find("Llave(Clone)"));
            }

            else if (hit.transform.gameObject.tag == "Encargado" || !papel)
            {
                GameManager.instance.InteractuarEncargado(2);

            }

            else if (hit.transform.gameObject.tag == "Encargado" || papel)
            {
                GameManager.instance.InteractuarEncargado(3);
            }
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
