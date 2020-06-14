﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject acera;
    private Transform boardHolder;
    private Transform boardHolder2;
    private Transform boardHolder3;
    private Transform boardHolder4;
    private Transform boardHolder5;
    public GameObject[] carretera;
    public GameObject[] mercadona;
    public GameObject[] casacomun;
    public GameObject[] casa1;
    public GameObject[] casa2;
    public GameObject[] casa3;
    public GameObject[] edificio1;
    public GameObject[] edificio2;
    public GameObject[] edificio3;
    public GameObject[] edificio4;
    public GameObject[] edificio5;
    public GameObject[] hospital;
    public GameObject[] tienda;
    public GameObject[] parque;
    public GameObject[] coches;
    public GameObject player;
    public GameObject[] horizontal;
    public GameObject[] vertical;
    public GameObject[] nevera1;
    public GameObject nevera2;
    public GameObject[] cesta;
    public GameObject[] cajaregistradora;
    public GameObject[] estanterias;
    public GameObject[] estanteriavacia;
    public GameObject sueloMercadona;
    public GameObject guardiaLlave;
    public GameObject carro;

    public void SetupScene()
    {
        boardHolder = new GameObject("Suelo").transform;
        boardHolder2 = new GameObject("Mercadona").transform;
        boardHolder3 = new GameObject("Casas").transform;
        boardHolder4 = new GameObject("Personajes").transform;
        boardHolder5 = new GameObject("Cestas").transform;


        /*string escenario = "60 60                                                       \n" +
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
                           "026666666666666666666622666666666666226666666666666666666623\n";*/


        string escenario =   "20 16               \n" +
                             "00 1 00             \n" +
                             "                    \n" +
                             "                    \n" +
                             "    222222222233    \n" +
                             "    222222222233    \n" +
                             "                    \n" +
                             "                    \n" +
                             "    MMM  2222222222 \n" +
                             "    MMM  2222222222 \n" +
                             "                    \n" +
                             "                    \n" +
                             "    MMM  2222222222 \n" +
                             "    MMM  2222222222 \n" +
                             "                    \n" +
                             "                    \n" +
                             "         44444444444\n";



        //Coches: tipo de coche, x inicial, y inicial, movimiento x, movimient y, direccion inicial, tipo de movimiento
        /*string personajes = "44      \n" +
                            "P 49 33 \n" +
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
                            "G 46 37  \n";*/

        string personajes = "1        \n" + 
                            "P 1 0    \n";

        string[] lineas = escenario.Split('\n');
        int xtotal = Convert.ToInt32(lineas[0].Split(' ')[0]);
        int ytotal = Convert.ToInt32(lineas[0].Split(' ')[1]);
        string[] jugadores = personajes.Split('\n');
        int ptotal = Convert.ToInt32(jugadores[0]);
        int m = 0;
        int c1 = 0;
        int c2 = 0;
        int c3 = 0;
        int e1 = 0;
        int e2 = 0;
        int e3 = 0;
        int e4 = 0;
        int e5 = 0;
        int h = 0;
        int t = 0;
        int p = 0;
        int n = 0;
        int e = 0;
        int v = 0;
        float xmapa;
        float ymapa;

        for (int y = 0; y < ytotal; y++)
        {
            ymapa = -y + ytotal-1;
            string linea = lineas[y + 1];

            for (int x = 0; x < xtotal; x++)
            {
                xmapa = x;
                char ch = linea[x];

                GameObject instance = null;

                switch (ch)
                {
                    case 'M':
                        if (ytotal == 60)
                        {
                            GameObject instancemercadona = Instantiate(mercadona[m], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            m++;

                            if (m == 44)
                                m = 0;

                            instancemercadona.transform.SetParent(boardHolder2);
                        }

                        else if (ytotal == 16)
                        {
                            GameObject caja = Instantiate(cajaregistradora[m], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            m++;

                            if (m == 6)
                                m = 0;

                            caja.transform.SetParent(boardHolder2);
                        }
                        
                        break;

                    case '0':
                        if (ytotal == 60)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (ytotal == 16)
                        {
                            instance = Instantiate(nevera1[n], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            n++;
                            if (n == 2)
                                n = 0;
                        }

                        break;

                    case '1':
                        if (ytotal == 60)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (ytotal == 16)
                        {
                            instance = Instantiate(nevera2, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        }
                        break;

                    case '2':
                        if (ytotal == 60)
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else if (ytotal == 16)
                        {
                            GameObject estanteria = Instantiate(estanterias[e], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            e++;

                            if (e == 20)
                                e = 0;

                            estanteria.transform.SetParent(boardHolder2);
                        }
                        break;

                    case '3':
                        if (ytotal == 60)
                        {
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        }

                        else if (ytotal == 16)
                        {
                            GameObject estanteria = Instantiate(estanteriavacia[v], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            v++;

                            if (v == 4)
                                v = 0;

                            estanteria.transform.SetParent(boardHolder2);
                        }
                        
                        break;

                    case '4':
                        if (ytotal == 60)
                        {
                            instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        }

                        else if (ytotal == 16)
                        {
                            GameObject carromercadona = Instantiate(carro, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                            carromercadona.transform.SetParent(boardHolder2);
                        }
                        
                        break;

                    case '5':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case '6':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case '7':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;
                    case '8':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case '9':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'A':
                        instance = Instantiate(carretera[10], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'B':
                        instance = Instantiate(carretera[11], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'C':
                        instance = Instantiate(carretera[12], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'D':
                        instance = Instantiate(carretera[13], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'E':
                        instance = Instantiate(carretera[14], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'F':
                        instance = Instantiate(carretera[15], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'G':
                        instance = Instantiate(carretera[16], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'H':
                        instance = Instantiate(carretera[17], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'I':
                        instance = Instantiate(carretera[18], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'J':
                        instance = Instantiate(carretera[19], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case 'Á':
                        GameObject bordecasa = Instantiate(casacomun[4], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa.transform.SetParent(boardHolder3);
                        break;

                    case 'É':
                        GameObject bordecasa2 = Instantiate(casacomun[5], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa2.transform.SetParent(boardHolder3);
                        break;

                    case 'Í':
                        GameObject bordecasa3 = Instantiate(casacomun[6], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa3.transform.SetParent(boardHolder3);
                        break;

                    case 'Ó':
                        GameObject bordecasa4 = Instantiate(casacomun[7], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa4.transform.SetParent(boardHolder3);
                        break;

                    case 'á':
                        GameObject bordecasa5 = Instantiate(casacomun[0], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa5.transform.SetParent(boardHolder3);
                        break;

                    case 'é':
                        GameObject bordecasa6 = Instantiate(casacomun[1], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa6.transform.SetParent(boardHolder3);
                        break;

                    case 'í':
                        GameObject bordecasa7 = Instantiate(casacomun[2], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa7.transform.SetParent(boardHolder3);
                        break;

                    case 'ó':
                        GameObject bordecasa8 = Instantiate(casacomun[3], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        bordecasa8.transform.SetParent(boardHolder3);
                        break;

                    case 'a':
                        GameObject casa1g = Instantiate(casa1[c1], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        c1++;
                        if (c1 == 16)
                            c1 = 0;
                        casa1g.transform.SetParent(boardHolder3);
                        break;

                    case 'b':
                        GameObject casa2g = Instantiate(casa2[c2], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        c2++;

                        if (c2 == 16)
                            c2 = 0;

                        casa2g.transform.SetParent(boardHolder3);
                        break;

                    case 'c':
                        GameObject casa3g = Instantiate(casa3[c3], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        c3++;
                        casa3g.transform.SetParent(boardHolder3);

                        if (c3 == 16)
                            c3 = 0;

                        break;

                    case 'd':
                        GameObject edificio1g = Instantiate(edificio1[e1], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e1++;
                        edificio1g.transform.SetParent(boardHolder3);

                        if (e1 == 20)
                            e1 = 0;

                        break;

                    case 'e':
                        GameObject edificio2g = Instantiate(edificio2[e2], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e2++;
                        edificio2g.transform.SetParent(boardHolder3);

                        if (e2 == 12)
                            e2 = 0;

                        break;

                    case 'f':
                        GameObject edificio3g = Instantiate(edificio3[e3], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e3++;
                        edificio3g.transform.SetParent(boardHolder3);
                        if (e3 == 18)
                            e3 = 0;
                        break;

                    case 'g':
                        GameObject edificio4g = Instantiate(edificio4[e4], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e4++;
                        edificio4g.transform.SetParent(boardHolder3);

                        if (e4 == 25)
                            e4 = 0;

                        break;

                    case 'h':
                        GameObject hospitalg = Instantiate(hospital[h], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        h++;
                        hospitalg.transform.SetParent(boardHolder3);

                        if (h == 25)
                            h = 0;

                        break;

                    case 'i':
                        GameObject edificio5g = Instantiate(edificio5[e5], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        e5++;
                        edificio5g.transform.SetParent(boardHolder3);

                        if (e5 == 25)
                            e5 = 0;

                        break;

                    case 'p':
                        GameObject parqueg = Instantiate(parque[p], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        p++;
                        parqueg.transform.SetParent(boardHolder3);

                        if (p == 80)
                            p = 0;

                        break;

                    case 't':
                        GameObject tiendag = Instantiate(tienda[t], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        t++;
                        tiendag.transform.SetParent(boardHolder3);

                        if (t == 20)
                            t = 0;

                        break;

                    default:
                        if (ymapa == 60)
                            instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);

                        else
                            instance = Instantiate(sueloMercadona, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;
                }

                if (instance != null)
                    instance.transform.SetParent(boardHolder);
            }
        }

        m = 0;
        h = 0;
          for (int pl = 0; pl < ptotal; pl++)
         {
             char ch = jugadores[pl + 1][0];
             GameObject instance = null;
             switch (ch)
             {
                 case 'P':
                     instance = Instantiate(player, new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     break;

                 case '0':
                     instance = Instantiate(coches[0], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol0 = instance.GetComponent<Coche>();
                     cochecontrol0.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol0.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol0.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol0.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case '1':
                     instance = Instantiate(coches[1], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol1 = instance.GetComponent<Coche>();
                     cochecontrol1.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol1.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol1.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol1.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case '2':
                     instance = Instantiate(coches[2], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol2 = instance.GetComponent<Coche>();
                     cochecontrol2.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol2.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol2.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol2.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case '3':
                     instance = Instantiate(coches[3], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol3 = instance.GetComponent<Coche>();
                     cochecontrol3.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol3.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol3.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol3.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case '4':
                     instance = Instantiate(coches[4], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                     Coche cochecontrol4 = instance.GetComponent<Coche>();
                     cochecontrol4.hormax = Int32.Parse(jugadores[pl + 1].Split(' ')[3]);
                     cochecontrol4.vermax = Int32.Parse(jugadores[pl + 1].Split(' ')[4]);
                     cochecontrol4.move = Int32.Parse(jugadores[pl + 1].Split(' ')[5]);
                     cochecontrol4.ordenmovimiento = Int32.Parse(jugadores[pl + 1].Split(' ')[6]);
                     break;

                 case 'V':
                     instance = Instantiate(vertical[m], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    m++;
                    if (m == 10)
                        m = 0;
                    break;

                 case 'H':
                     instance = Instantiate(horizontal[h], new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    h++;
                    if (h == 10)
                        h = 0;
                     break;

                case 'G':
                    instance = Instantiate(guardiaLlave, new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    break;
            }

             if (instance != null)
                 instance.transform.SetParent(boardHolder4);
    
        }
    }
}
        
    