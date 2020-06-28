using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Player : MovingObject
{
    public float restartLevelDelay = 1f;
    int countf = 0;
    int countb = 0;
    int countl = 0;
    int countr = 0;
    int tiempoupdate = 0;
    public int estado;
    int horizontal;
    int vertical;
    bool accion1;
    bool accion2;
    bool inter = false;
    bool llave;
    bool papel = false;
    bool cesta = false;
    bool codigo = false;
    public Sprite propietarioarriba;
    public Sprite propietarioderecha;
    public Sprite propietarioizquierda;
    public bool animacion = false;
    public GameObject llaveobject;
    private Text estadoVida;
    private Animator animator;
    public int health; //puntos de vida 
    public bool contagiado = false;
    public Vector2 startPos;
    public Vector2 direction;
    List<Vector3> posicionrandom = new List<Vector3>();
    Vector3 posicionRandom1;
    Vector3 posicionRandom2;
    Vector3 posicionRandom3;
    private bool posicion1;
    private bool posicion2;
    private bool posicion3;

    protected override void Awake()
    {
        animator = GetComponent<Animator>();
        base.Awake();
    }

    protected override void Start()
    {
        health = GameManager.instance.healthPoints;
        contagiado = GameManager.instance.contagio;
        estadoVida = GameObject.Find("EstadoText").GetComponent<Text>();
        estadoVida.text = "Vida: " + health;
        //CAMBIAR TODO A FALSE
        accion1 = false;
        accion2 = false;
        codigo = false;
        papel = false;
        llave = GameManager.instance.llave;

        CambiarIdle(estado);

        base.Start();
    }

    /*private void OnDisable()
    {
        GameManager.instance.healthPoints = health;
    }*/

    void CheckIfGameOver()
    {
        if (health <= 0)
        {
            SoundManager.instance.gameover();
            GameManager.instance.GameOver();
        }
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
                    if (Mathf.Abs(direction.x) < 50 && Mathf.Abs(direction.y) < 50)
                    {
                        inter = true;
                        //GameManager.instance.Sensibilidad(direction);
                        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                        {
                            if (direction.x > 0)
                            {
                                estado = 3;
                                CambiarIdle(estado);
                            }

                            else
                            {
                                estado = 2;
                                CambiarIdle(estado);
                            }
                        }
                    }

                    else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
                    {
                        if (direction.y > 0)
                        {
                            estado = 0;
                            CambiarIdle(estado);
                        }


                        else
                        {
                            estado = 1;
                            CambiarIdle(estado);
                        }
                    }
                    horizontal = 0;
                    vertical = 0;
                    direction.x = 0;
                    direction.y = 0;
                    break;
            }

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y) && Mathf.Abs(direction.x) > 50)
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

            else if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x) && Mathf.Abs(direction.y) > 50)
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

        if (!moving && !animacion && !GameManager.instance.doingSetup)
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
            if (GameObject.Find("Encargado1"))
            {
                GameManager.instance.AcabarConversa();
                animacion = false;
            }

            else
            {
                if (estado == 0)
                {
                    ComprovarDialogo(0, 1);

                }
                else if (estado == 1)
                {
                    ComprovarDialogo(0, -1);

                }
                else if (estado == 2)
                {
                    ComprovarDialogo(-1, 0);
                }
                else if (estado == 3)
                {
                    ComprovarDialogo(1, 0);
                }
            }

            if (inter)
                inter = false;
        }
        ComprobarPosicion();
    }

    private void ComprobarPosicion()
    {
        if (GameManager.instance.nivel == 2)
        {
            if (transform.position.x == 1 && transform.position.y == 1 && !accion1)
            {
                animacion = true;
                GameManager.instance.InteractuarEncargado(2);
                accion1 = true;
                CambiarIdle(3);
            }

            else if (transform.position.x == 1 && transform.position.y == 14 && !cesta)
            {
                CambiarIdle(0);
                cesta = true;
                GameManager.instance.InteractuarEncargado(3);
                animacion = true;
                CambiarIdle(0);
            }

            if (posicionRandom1 != null && !codigo)
            {
                if (transform.position.x == posicionRandom1.x && transform.position.y == posicionRandom1.y && !posicion1)
                {
                    posicion1 = true;
                    animacion = true;
                    CambiarIdle(0);
                    GameManager.instance.InteractuarEncargado(5);
                }

                else if (transform.position.x == posicionRandom2.x && transform.position.y == posicionRandom2.y && !posicion2)
                {
                    posicion2 = true;
                    animacion = true;
                    CambiarIdle(0);
                    GameManager.instance.InteractuarEncargado(6);
                }

                else if (transform.position.x == posicionRandom3.x && transform.position.y == posicionRandom3.y && !posicion3)
                {
                    posicion3 = true;
                    animacion = true;
                    CambiarIdle(0);
                    GameManager.instance.InteractuarEncargado(7);
                }

                if (posicion1 && posicion2 && posicion3)
                {
                    codigo = true;
                    animacion = true;
                    CambiarIdle(0);
                    GameManager.instance.InteractuarEncargado(8);
                }
            }
        }

        else if (GameManager.instance.nivel == 3)
        {
            if (transform.position.x == 17 && transform.position.y == 0 && !accion1)
            {
                animacion = true;
                GameManager.instance.InteractuarEncargado(11);
                accion1 = true;
                CambiarIdle(3);
            }

            else if (transform.position.x == 17 && transform.position.y == 0 && papel && !accion2)
            {
                animacion = true;
                GameManager.instance.InteractuarEncargado(12);
                CambiarIdle(3);
                accion2 = true;
            }
        }

        else if (GameManager.instance.nivel == 4)
        {
            if (transform.position.x == 1 && transform.position.y == 1 && !accion1)
            {
                animacion = true;
                GameManager.instance.InteractuarEncargado(13);
                accion1 = true;
                CambiarIdle(3);
            }
        }
    }

    private void ComprovarDialogo(int xDir, int yDir)
    {
        Vector2 final = new Vector2(transform.position.x + xDir, transform.position.y + yDir);
        RaycastHit2D hit = Physics2D.Linecast(transform.position, final, blockingLayer);

        if (hit.transform != null)
        {
            if (hit.transform.gameObject.tag == "GuardiaLlave")
            {
                GameManager.instance.InteractuarEncargado(1);
                animacion = true;

                if (GameObject.Find("Llave(Clone)") == null && !llave)
                {
                    posicionrandom.Add(new Vector3(2f, 2f, 0f));
                    posicionrandom.Add(new Vector3(2f, 57f, 0f));
                    posicionrandom.Add(new Vector3(57f, 2f, 0f));
                    posicionrandom.Add(new Vector3(57f, 57f, 0f));
                    int randomIndex = Random.Range(0, posicionrandom.Count);
                    Vector3 randomPosition = posicionrandom[randomIndex];
                    llaveobject = Instantiate(llaveobject, randomPosition, Quaternion.identity);
                    posicionrandom.Clear();
                }
                    
            }

            else if (hit.transform.gameObject.tag == "Llave")
            {
                llave = true;
                Destroy(GameObject.Find("Llave(Clone)"));
                GameManager.instance.llave = true;
                GameManager.instance.puntos = GameManager.instance.puntos + 100;
            }

            else if (hit.transform.gameObject.tag == "Codigo" && codigo)
            {
                animacion = true;
                codigo = true;
                GameManager.instance.InteractuarEncargado(9);
                Animator animacionpuerta = GameObject.Find("PuertaAlmacenLarge(Clone)").GetComponent<Animator>();
                animacionpuerta.SetTrigger("AbrirMercadona");
                StartCoroutine(esperar(0));
            }

            else if (hit.transform.gameObject.tag == "Codigo" && !codigo)
            {
                animacion = true;
                GameManager.instance.InteractuarEncargado(10);
            }

            else if (hit.transform.gameObject.tag == "PropietarioMercadona")
            {
                SpriteRenderer propietario = hit.transform.gameObject.GetComponent<SpriteRenderer>();
                if (estado == 1)
                    propietario.sprite = propietarioarriba;

                else if (estado == 2)
                    propietario.sprite = propietarioderecha;

                else if (estado == 3)
                    propietario.sprite = propietarioizquierda;

                animacion = true;
                if (GameManager.instance.nivel == 2)
                {
                    if (!cesta)
                        GameManager.instance.InteractuarEncargado(2);

                    else if (!codigo)
                    {
                        GameManager.instance.InteractuarEncargado(4);
                        if (posicionrandom.Count == 0)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                posicionrandom.Add(new Vector3(8 + i, 2f, 0f));
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                posicionrandom.Add(new Vector3(8 + i, 6f, 0f));
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                posicionrandom.Add(new Vector3(6 + i, 10f, 0f));
                            }

                            int randomIndex = Random.Range(0, posicionrandom.Count);
                            posicionRandom1 = posicionrandom[randomIndex];
                            posicionrandom.RemoveAt(randomIndex);
                            randomIndex = Random.Range(0, posicionrandom.Count);
                            posicionRandom2 = posicionrandom[randomIndex];
                            posicionrandom.RemoveAt(randomIndex);
                            randomIndex = Random.Range(0, posicionrandom.Count);
                            posicionRandom3 = posicionrandom[randomIndex];
                            posicionrandom.RemoveAt(randomIndex);
                        }
                    }

                    else if (codigo)
                    {
                        animacion = true;
                        GameManager.instance.InteractuarEncargado(15);
                    }
                }
                
                else if (GameManager.instance.nivel == 3)
                {
                    if (!papel)
                    {
                        animacion = true;
                        GameManager.instance.InteractuarEncargado(11);
                    }

                    else if (papel)
                    {
                        animacion = true;
                        GameManager.instance.InteractuarEncargado(12);
                    }
                }
            }

            else if (hit.transform.gameObject.tag == "Papel")
            {
                Destroy(hit.transform.gameObject);
                animacion = true;
                GameManager.instance.InteractuarEncargado(16);
                papel = true;
            }

            else if (hit.transform.gameObject.tag == "ConjuntoPapel")
            {
                animacion = true;
                GameManager.instance.InteractuarEncargado(17);
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
        if (estado == 0)
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
        this.estado = estado;
    }

    IEnumerator esperar(int i)
    {
        yield return new WaitForSeconds(1);
        if (i == 1)
        {
            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(0, 1);
            StartCoroutine(SmoothMovement(end));
            Invoke("Restart", restartLevelDelay);
        }

        else if (i == 0)
        {
            if (GameObject.Find("Encagardo1") == null)
                animacion = false;
        }
    }

    protected override void OnCantMove(GameObject go)
    {
        if (go.tag == "PuertaMercadona")
        {
            if (!llave)
            {
                animacion = true;
                GameManager.instance.InteractuarEncargado(19);
            }

            else if (GameManager.instance.nivel == 1)
            {
                animacion = true;
                Animator animacionpuerta = go.GetComponent<Animator>();
                animacionpuerta.SetTrigger("AbrirMercadona");
                StartCoroutine(esperar(1));
                GameManager.instance.puntos = GameManager.instance.puntos + 100;
            }

            else if (GameManager.instance.nivel == 5)
            {
                animacion = true;
                GameManager.instance.InteractuarEncargado(20);
            }
        } 

        if (go.tag == "PuertaAlmacen" && codigo)
        {
            animacion = true;
            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(0, 1);
            StartCoroutine(SmoothMovement(end));
            Invoke("Restart", restartLevelDelay);
        }

        if (go.tag == "Borde")
        {
            if (GameManager.instance.nivel == 3 && papel && transform.position.x == 17 && transform.position.y == 0)
            {
                Vector2 start = transform.position;
                Vector2 end = start + new Vector2(0, -1);
                StartCoroutine(SmoothMovement(end));
                Invoke("Restart", restartLevelDelay);
            }

            else if (GameManager.instance.nivel == 4 && transform.position.x == 1 && transform.position.y == 0)
            {
                Vector2 start = transform.position;
                Vector2 end = start + new Vector2(0, -1);
                StartCoroutine(SmoothMovement(end));
                Invoke("Restart", restartLevelDelay);
            }
        }

        if (transform.position.x == 7 && transform.position.y == 3)
        {
            if (GameManager.instance.nivel == 1)
            {
                animacion = true;
                GameManager.instance.InteractuarEncargado(21);
            }
        }
    }

  void Restart()
    {
        GameManager.instance.healthPoints = health;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void LoseHealth(int loss)
    {
        health -= loss;
        contagiado = true;
        SoundManager.instance.contagio();
        StartCoroutine(Contagio(5));
        CheckIfGameOver();
        estadoVida.text = "Vida: " + health;

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
            estadoVida.text = "Vida: " + health;
            perdida++;
            yield return new WaitForSeconds(1);
        }
        
    }

    public void pillado()
    {
        GameManager.instance.llave = llave;
        GameManager.instance.nivel = 6;
        Invoke("Restart", restartLevelDelay);
        posicionrandom.Clear();
    }
}
