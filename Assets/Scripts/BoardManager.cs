using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject acera;
    private Transform boardHolder;
    private Transform boardHolder2;
    private Transform boardHolder3;
    public GameObject[] carretera;
    public GameObject[] mercadona;
    public GameObject[] casa1;
    public GameObject[] casa2;
    public GameObject[] casa3;
    public GameObject player;
    public GameObject enemigov;
    public GameObject enemigoh;

    public void SetupScene()
    {
        boardHolder = new GameObject("Suelo").transform;
        boardHolder2 = new GameObject("Mercadona").transform;
        boardHolder3 = new GameObject("Casas").transform;


        string escenario = "40 40\n" +
                           "A95555555555555555555555555555555555559C\n" +
                           "7B666666666666666666666666666666666666D8\n" +
                           "EF                         MMMMMMMMMMMEF\n" +
                           "EF                         MMMMMMMMMMMEF\n" +
                           "EF                         MMMMMMMMMMMEF\n" +
                           "EF                         MMMMMMMMMMMEF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "71555555555555555555G5555555555555555548\n" +
                           "7B666666666666666666H66666666666666666D8\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "EF                                    EF\n" +
                           "71555555555555555555G5555555555555555548\n" +
                           "7B6666666666666DB666H6666DB66666666666D8\n" +
                           "EF             EF        EF           EF\n" +
                           "EF             EF        EF           EF\n" +
                           "EF  aaaa bbbb  EF        EF  cccc     EF\n" +
                           "EF  aaaa bbbb  IJ        IJ  cccc     EF\n" +
                           "EF  aaaa bbbb  EF        EF  cccc     EF\n" +
                           "EF             EF        EF           EF\n" +
                           "EF             EF        EF           EF\n" +
                           "7155555555555554155555555415555555555548\n" +
                           "0266666666666666666666666666666666666623\n";

        string personajes = "9   \n" +
                            "P 0 4  \n" +
                            "V -2 -3  \n" +
                            "V -1 -3  \n" +
                            "V 5 -3  \n" +
                            "V 1 -3  \n" +
                            "H 2 -3  \n" +
                            "H 3 -3  \n" +
                            "H 4 -3  \n" +
                            "H -14 -13\n";

        string[] lineas = escenario.Split('\n');
        int xtotal = Convert.ToInt32(lineas[0].Split(' ')[0]);
        int ytotal = Convert.ToInt32(lineas[0].Split(' ')[1]);
        string[] jugadores = personajes.Split('\n');
        int ptotal = Convert.ToInt32(jugadores[0]);
        int m = 0;
        int c1 = 0;
        int c2 = 0;
        int c3 = 0;

        for (int y = 0; y < ytotal; y++)
        {
            string linea = lineas[y + 1];

            for (int x = 0; x < xtotal; x++)
            {
                char ch = linea[x];

                GameObject instance;

                switch (ch)
                {
                    case 'M':
                        GameObject instance2 = Instantiate(mercadona[m], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        m++;
                        instance2.transform.SetParent(boardHolder2);
                        break;

                    case '0':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case '1':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case '2':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case '3':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case '4':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case '5':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case '6':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case '7':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;
                    case '8':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case '9':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'A':
                        instance = Instantiate(carretera[10], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'B':
                        instance = Instantiate(carretera[11], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'C':
                        instance = Instantiate(carretera[12], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'D':
                        instance = Instantiate(carretera[13], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'E':
                        instance = Instantiate(carretera[14], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'F':
                        instance = Instantiate(carretera[15], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'G':
                        instance = Instantiate(carretera[16], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'H':
                        instance = Instantiate(carretera[17], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'I':
                        instance = Instantiate(carretera[18], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'J':
                        instance = Instantiate(carretera[19], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;

                    case 'a':
                        GameObject instance3 = Instantiate(casa1[c1], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        c1++;
                        instance3.transform.SetParent(boardHolder3);
                        break;

                    case 'b':
                        GameObject instance4 = Instantiate(casa2[c2], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        c2++;
                        instance4.transform.SetParent(boardHolder3);
                        break;

                    case 'c':
                        GameObject instance5 = Instantiate(casa3[c3], new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        c3++;
                        instance5.transform.SetParent(boardHolder3);
                        break;

                    default:
                        instance = Instantiate(acera, new Vector3(x - 19f, -y + 19f, 0f), Quaternion.identity);
                        break;
                }
                instance.transform.SetParent(boardHolder);

            }
        }

        for (int p = 0; p < ptotal; p++)
        {
            char ch = jugadores[p + 1][0];
            GameObject instance;
            switch (ch)
            {
                case 'P':
                    instance = Instantiate(player, new Vector3(Convert.ToInt32(jugadores[p+1].Split(' ')[1]), Convert.ToInt32(jugadores[p + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    break;

                case 'V':
                    instance = Instantiate(enemigov, new Vector3(Convert.ToInt32(jugadores[p + 1].Split(' ')[1]), Convert.ToInt32(jugadores[p + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    break;

                case 'H':
                    instance = Instantiate(enemigoh, new Vector3(Convert.ToInt32(jugadores[p + 1].Split(' ')[1]), Convert.ToInt32(jugadores[p + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    break;
            }
        }
    }
}
        
    