using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject acera;
    private Transform boardHolder;
    public GameObject[] carretera;
    public GameObject[] mercadona;
    public GameObject player;

    public void SetupScene()
    {
        GameObject jugador = Instantiate(player, new Vector3(0f, 0f, 0f), Quaternion.identity);
        boardHolder = new GameObject("Board").transform;


        string escenario = "20 20               \n" +
                           "2                  3\n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "     111111111      \n" +
                           "     111111111      \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "                    \n" +
                           "1                  4\n";

        string[] lineas = escenario.Split('\n');
        int xtotal = Convert.ToInt32(lineas[0].Split(' ')[0]);
        int ytotal = Convert.ToInt32(lineas[0].Split(' ')[1]);

        for (int y=0; y<ytotal; y++)
        {
            string linea = lineas[y+1];

            for(int x=0; x<xtotal; x++)
            {
                char ch = linea[x];

                GameObject instance;

                switch (ch)
                {
                    default:
                    instance = Instantiate(acera, new Vector3(x-9.5f, y-9.5f, 0f), Quaternion.identity);
                        break;
                }
                instance.transform.SetParent(boardHolder);

            }

        }
    }
}
