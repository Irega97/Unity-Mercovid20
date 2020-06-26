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
    int nivel = 0;
    string mapa;
    string personajes;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

		boardScript = GetComponent<BoardManager>();
        //Se lee de Android
                    mapa = "60 60 1                                                    \n" +
                           "A9555555555555555555559955555555599599555555555555555555559C\n" +
                           "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "7155555555555599555555415555G5555555415555559955555555555548\n" +
                           "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF   hhhhh                    EF            EF\n" +
                           "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                           "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "71555555555555415555G555555555555555G55555554155555555555548\n" +
                           "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg           pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff                                  ggggg iiiiiEF\n" +
                           "EFddddd ffff                                   ggggg iiiiiEF\n" +
                           "EF                                                        EF\n" +
                           "EF                                                        EF\n" +
                           "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                           "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF     hhhhh                  EF            EF\n" +
                           "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                           "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "7155555555555541555555995555G5555995555555554155555555555548\n" +
                           "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "715555555555555555555541555555555555415555555555555555555548\n" +
                           "026666666666666666666622666666666666226666666666666666666623\n";

               personajes = "44      \n" +
                            "PP 49 33 1         \n" +
                            "0 0 0 23 11 0 0    \n" +
                            "1 0 48 23 11 0 0   \n" +
                            "2 36 48 23 11 0 0  \n" +
                            "3 36 0 23 11 0 0   \n" +
                            "4 22 0 15 11 0 0   \n" +
                            "0 0 10 15 11 0 0   \n" +
                            "1 44 10 15 11 0 0  \n" +
                            "2 44 38 15 11 0 0  \n" +
                            "3 0 38 15 11 0 0   \n" +
                            "4 22 48 15 11 0 0  \n" +
                            "0 0 20 59 19 0 0   \n" +
                            "1 22 1 21 9 2 1    \n" +
                            "2 58 1 21 9 2 1    \n" +
                            "3 58 49 21 9 2 1   \n" +
                            "4 22 49 21 9 2 1   \n" +
                            "0 58 39 13 9 2 1   \n" +
                            "1 36 1 13 9 2 1    \n" +
                            "2 58 11 13 9 2 1   \n" +
                            "3 14 11 13 9 2 1   \n" +
                            "4 14 39 13 9 2 1   \n" +
                            "0 36 49 13 9 2 1   \n" +
                            "1 58 21 57 17 2 1  \n" +
                            "H 24 9   \n" +
                            "H 2 22   \n" +
                            "H 2 30   \n" +
                            "H 57 30  \n" +
                            "H 16 40  \n" +
                            "H 24 50  \n" +
                            "H 40 37  \n" +
                            "H 16 19  \n" +
                            "H 43 12  \n" +
                            "H 43 47  \n" +
                            "V 21 2   \n" +
                            "V 38 9   \n" +
                            "V 13 12  \n" +
                            "V 46 19  \n" +
                            "V 23 37  \n" +
                            "V 34 22  \n" +
                            "V 13 47  \n" +
                            "V 21 50  \n" +
                            "V 46 40  \n" +
                            "V 38 57  \n" +
                            "G 46 37  \n";
        nivel++;
        InitGame();
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

        boardScript.SetupScene(mapa, personajes);

        Invoke("HidePresentacion", levelStartDelay);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static public void CallbackInitialization()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    static private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        Debug.Log(instance.nivel);
        //Pedir cosas a Android
        if (instance.nivel == 1)
            {
             instance.mapa = "20 16 2             \n" +
                             "33333333 001100117 8\n" +
                             "3                   \n" +
                             "3                   \n" +
                             "3     2222222222    \n" +
                             "3     2222222222    \n" +
                             "3                   \n" +
                             "                    \n" +
                             "   MMM  2222222222  \n" +
                             "   MMM  2222222222  \n" +
                             "                    \n" +
                             "                    \n" +
                             "   MMM  2222222222  \n" +
                             "   MMM  2222222222  \n" +
                             "                    \n" +
                             "                    \n" +
                             "565       44444444444\n";

            instance.personajes = "2                 \n" +
                                  "P 1 0 0           \n" +
                                  "G 18 10 16 4 0 0\n";

        }

        else if (instance.nivel == 2)
        {

        }

        else if (instance.nivel == 3)
        {
            instance.mapa = "20 16 2             \n" +
                             "33333333 001100117 8\n" +
                             "3                   \n" +
                             "3                   \n" +
                             "3     2222222222    \n" +
                             "3     2222222222    \n" +
                             "3                   \n" +
                             "                    \n" +
                             "   MMM  2222222222  \n" +
                             "   MMM  2222222222  \n" +
                             "                    \n" +
                             "                    \n" +
                             "   MMM  2222222222  \n" +
                             "   MMM  2222222222  \n" +
                             "                    \n" +
                             "                    \n" +
                             "565       44444444444\n";

            instance.personajes = "2                 \n" +
                                  "P 1 0 0           \n" +
                                  "G 18 10 16 4 0 0\n";
        }

        else if (instance.nivel == 4)
        {
            instance.mapa = "60 60 1                                                    \n" +
                           "A9555555555555555555559955555555599599555555555555555555559C\n" +
                           "7B66666666666666666666DB666666666666DB66666666666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "7155555555555599555555415555G5555555415555559955555555555548\n" +
                           "7B666666666666DB666666226666H666666622666666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF   hhhhh                    EF            EF\n" +
                           "EF   Áccccá   EF   hhhhh       ttttt        EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   IJ   hhhhh       ttttt        IJ   Éaaaaé   EF\n" +
                           "EF   Íccccí   EF   hhhhh       ttttt        EF   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF   hhhhh       ttttt        EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "71555555555555415555G555555555555555G55555554155555555555548\n" +
                           "7B666666666666226666H666666666666666H666666622666666666666D8\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            fffff MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg                            ffff  MMMMMMMMMMMEF\n" +
                           "EFiiiii ggggg           pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp                        EF\n" +
                           "EF                      pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd ffff            pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff           pppppppppp             ggggg iiiiiEF\n" +
                           "EFddddd fffff                                  ggggg iiiiiEF\n" +
                           "EFddddd ffff                                   ggggg iiiiiEF\n" +
                           "EF                                                        EF\n" +
                           "EF                                                        EF\n" +
                           "71555555555555995555G5555555555555555555G5559955555555555548\n" +
                           "7B666666666666DB6666H6666666666666666666H666DB666666666666D8\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF     hhhhh                  EF            EF\n" +
                           "EF   Áccccá   EF     hhhhh       ttttt      EF   Áaaaaá   EF\n" +
                           "EF   Éccccé   EF     hhhhh       ttttt      EF   Éaaaaé   EF\n" +
                           "EF   Íccccí   IJ     hhhhh       ttttt      IJ   Íaaaaí   EF\n" +
                           "EF   Óccccó   EF     hhhhh       ttttt      EF   Óaaaaó   EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "EF            EF                            EF            EF\n" +
                           "7155555555555541555555995555G5555995555555554155555555555548\n" +
                           "7B66666666666622666666DB6666H6666666DB66666622666666666666D8\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF    eee     EF   Áccccá  ddddd    EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF    eee     EF   Éccccé  ddddd    EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ    eee     IJ   Íccccí  ddddd    EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF    eee     EF   Óccccó  ddddd    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "EF                    EF            EF                    EF\n" +
                           "715555555555555555555541555555555555415555555555555555555548\n" +
                           "026666666666666666666622666666666666226666666666666666666623\n";

            instance.personajes = "44      \n" +
                         "P 49 33 1          \n" +
                         "0 0 0 23 11 0 0    \n" +
                         "1 0 48 23 11 0 0   \n" +
                         "2 36 48 23 11 0 0  \n" +
                         "3 36 0 23 11 0 0   \n" +
                         "4 22 0 15 11 0 0   \n" +
                         "0 0 10 15 11 0 0   \n" +
                         "1 44 10 15 11 0 0  \n" +
                         "2 44 38 15 11 0 0  \n" +
                         "3 0 38 15 11 0 0   \n" +
                         "4 22 48 15 11 0 0  \n" +
                         "0 0 20 59 19 0 0   \n" +
                         "1 22 1 21 9 2 1    \n" +
                         "2 58 1 21 9 2 1    \n" +
                         "3 58 49 21 9 2 1   \n" +
                         "4 22 49 21 9 2 1   \n" +
                         "0 58 39 13 9 2 1   \n" +
                         "1 36 1 13 9 2 1    \n" +
                         "2 58 11 13 9 2 1   \n" +
                         "3 14 11 13 9 2 1   \n" +
                         "4 14 39 13 9 2 1   \n" +
                         "0 36 49 13 9 2 1   \n" +
                         "1 58 21 57 17 2 1  \n" +
                         "H 24 9   \n" +
                         "H 2 22   \n" +
                         "H 2 30   \n" +
                         "H 57 30  \n" +
                         "H 16 40  \n" +
                         "H 24 50  \n" +
                         "H 40 37  \n" +
                         "H 16 19  \n" +
                         "H 43 12  \n" +
                         "H 43 47  \n" +
                         "V 21 2   \n" +
                         "V 38 9   \n" +
                         "V 13 12  \n" +
                         "V 46 19  \n" +
                         "V 23 37  \n" +
                         "V 34 22  \n" +
                         "V 13 47  \n" +
                         "V 21 50  \n" +
                         "V 46 40  \n" +
                         "V 38 57  \n" +
                         "G 46 37  \n";
        }
        instance.nivel++;
        instance.InitGame();
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

    /*private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinshedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinshedLoading;
    }*/

    public void GameOver()
    {
        enabled = false;
    }

    /*private void OnLevelFinshedLoading(Scene scene, LoadSceneMode mode)
    {
        InitGame();

    }*/

    public void Sensibilidad(Vector2 movimiento)
    {
        encargado1.SetActive(true);
        Text texto = encargado1.GetComponent<Text>();
        texto.text = "X: " + movimiento.x + " Y: " + movimiento.y;
        Invoke("AcabarConversa", levelStartDelay);
    }
}
