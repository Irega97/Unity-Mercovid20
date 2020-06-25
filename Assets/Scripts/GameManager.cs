using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BoardManager boardScript;
    public static GameManager instance = null;
    public int healthPoints = 100;
    public bool contagio = false;
    public float levelStartDelay = 5f;
    public GameObject presentacion;
    public GameObject encargado1;
    public GameObject encargado2;
    public GameObject encargado3;
    public bool doingSetup;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
		boardScript = GetComponent<BoardManager>();
    }

    void InitGame()
    {
        doingSetup = true;
        presentacion = GameObject.Find("Presentacion");
        encargado1 = GameObject.Find("Encargado1");
        encargado2 = GameObject.Find("Encargado2");
        encargado3 = GameObject.Find("Encargado3");

        AcabarConversa();

        presentacion.SetActive(true);

        boardScript.SetupScene();

        Invoke("HidePresentacion", levelStartDelay);
    }

    private void HidePresentacion()
    {
        presentacion.SetActive(false);
        doingSetup = false;
    }

    public void InteractuarEncargado(int inter)
    {
        if (inter == 1)
        {
            encargado1.SetActive(true);
            Invoke("AcabarConversa", levelStartDelay);
        }   
        /*else if (inter == 2)
        {
            encargado2.SetActive(true);
            Invoke("AcabarConversa", levelStartDelay);
        } 
        else if (inter == 3)
        {
            encargado3.SetActive(true);
            Invoke("AcabarConversa", levelStartDelay);
        }*/
    }

    private void AcabarConversa()
    {
        encargado1.SetActive(false);
        encargado2.SetActive(false);
        encargado3.SetActive(false);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinshedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinshedLoading;
    }

    public void GameOver()
    {
        enabled = false;
    }

    private void OnLevelFinshedLoading(Scene scene, LoadSceneMode mode)
    {
        InitGame();

    }
}
