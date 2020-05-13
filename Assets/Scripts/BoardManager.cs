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
    public GameObject[] carretera;
    public GameObject[] mercadona;
    public GameObject player;

    public void SetupScene()
    {
        GameObject jugador = Instantiate(player, new Vector3(0f, 0f, 0f), Quaternion.identity);
        boardHolder = new GameObject("Suelo").transform;
        boardHolder2 = new GameObject("Mercadona").transform;


        string escenario = "20 20               \n" +
                           "A955555555555555559C\n" +
                           "7B6666666666666666D8\n" +
                           "EF     MMMMMMMMMMMEF\n" +
                           "EF     MMMMMMMMMMMEF\n" +
                           "EF     MMMMMMMMMMMEF\n" +
                           "EF     MMMMMMMMMMMEF\n" +
                           "EF                EF\n" +
                           "EF                EF\n" +
                           "EF                EF\n" +
                           "EF                EF\n" +
                           "71555555555G55555548\n" +
                           "7B666666666H666666D8\n" +
                           "EF                EF\n" +
                           "EF                EF\n" +
                           "EF                EF\n" +
                           "EF                EF\n" +
                           "EF                EF\n" +
                           "EF                EF\n" +
                           "71555555555555555548\n" +
                           "02666666666666666623\n";

        string[] lineas = escenario.Split('\n');
        int xtotal = Convert.ToInt32(lineas[0].Split(' ')[0]);
        int ytotal = Convert.ToInt32(lineas[0].Split(' ')[1]);
        int m = 0;

        for (int y=0; y<ytotal; y++)
        {
            string linea = lineas[y+1];

            for(int x=0; x<xtotal; x++)
            {
                char ch = linea[x];

                GameObject instance;

                switch (ch)
                {
                    case 'M':
                        GameObject instance2 = Instantiate(mercadona[m], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        m++;
                        instance2.transform.SetParent(boardHolder2);
                        break;

                    case '0':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case '1':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case '2':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case '3':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case '4':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case '5':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case '6':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case '7':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;
                    case '8':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case '9':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'A':
                        instance = Instantiate(carretera[10], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'B':
                        instance = Instantiate(carretera[11], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'C':
                        instance = Instantiate(carretera[12], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'D':
                        instance = Instantiate(carretera[13], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'E':
                        instance = Instantiate(carretera[14], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'F':
                        instance = Instantiate(carretera[15], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'G':
                        instance = Instantiate(carretera[16], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'H':
                        instance = Instantiate(carretera[17], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'I':
                        instance = Instantiate(carretera[18], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    case 'J':
                        instance = Instantiate(carretera[19], new Vector3(x - 9f, -y + 9f, 0f), Quaternion.identity);
                        break;

                    default:
                    instance = Instantiate(acera, new Vector3(x-9f, -y+9f, 0f), Quaternion.identity);
                        break;
                }
                instance.transform.SetParent(boardHolder);

            }

        }
    }
}
