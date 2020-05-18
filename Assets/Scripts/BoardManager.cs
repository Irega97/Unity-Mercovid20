using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditorInternal;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject acera;
    private Transform boardHolder;
    private Transform boardHolder2;
    private Transform boardHolder3;
    private Transform boardHolder4;
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
    public GameObject player;
    public GameObject enemigov;
    public GameObject enemigoh;

    public void SetupScene()
    {
        boardHolder = new GameObject("Suelo").transform;
        boardHolder2 = new GameObject("Mercadona").transform;
        boardHolder3 = new GameObject("Casas").transform;
        boardHolder4 = new GameObject("Personajes").transform;


        string escenario = "60 60                                                       \n" +
                           "A9555555555555555555555555555555555555555555555555555555559C\n" +
                           "7B66666666666666666666666666666666666666666666666666666666D8\n" +
                           "EF                    EF         EF                       EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF   eee   EF   Áccccá    ddddd     EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF   eee   EF   Éccccé    ddddd     EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ   eee   IJ   Íccccí    ddddd     EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF   eee   EF   Óccccó    ddddd     EF\n" +
                           "EF                    EF         EF                       EF\n" +
                           "EF                    EF         EF                       EF\n" +
                           "EF                    EF         EF                       EF\n" +
                           "7155555555555599555555415555G5555415555555559955555555555548\n" +
                           "7B666666666666DB666666226666H666622666666666DB666666666666D8\n" +
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
                           "7B66666666666622666666DB6666H6666DB66666666622666666666666D8\n" +
                           "EF                    EF         EF                       EF\n" +
                           "EF                    EF         EF                       EF\n" +
                           "EF   Ábbbbá  Áaaaaá   EF         EF   Áccccá    ddddd     EF\n" +
                           "EF   Ébbbbé  Éaaaaé   EF   eee   EF   Éccccé    ddddd     EF\n" +
                           "EF   Íbbbbí  Íaaaaí   IJ   eee   IJ   Íccccí    ddddd     EF\n" +
                           "EF   Óbbbbó  Óaaaaó   EF   eee   EF   Óccccó    ddddd     EF\n" +
                           "EF                    EF   eee   EF                       EF\n" +
                           "EF                    EF         EF                       EF\n" +
                           "715555555555555555555541555555555415555555555555555555555548\n" +
                           "026666666666666666666622666666666226666666666666666666666623\n";

        string personajes = "13       \n" +
                            "P -22 -27\n" +
                            "H -5 -21 \n" +
                            "H -13 -11\n" +
                            "H -5 20  \n" +
                            "H -13 10 \n" +
                            "V -8 -21 \n" +
                            "V 6 -21  \n" +
                            "V -16 -11\n" +
                            "V 17 -11 \n" +
                            "V -16 17 \n" +
                            "V 17 17  \n" +
                            "V -8 27  \n" +
                            "V 6 27   \n";

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
        float xmapa;
        float ymapa;

        for (int y = 0; y < ytotal; y++)
        {
            ymapa = -y + 29;
            string linea = lineas[y + 1];

            for (int x = 0; x < xtotal; x++)
            {
                xmapa = x - 29;
                char ch = linea[x];

                GameObject instance;

                switch (ch)
                {
                    case 'M':
                        GameObject instancemercadona = Instantiate(mercadona[m], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        m++;

                        if (m == 44)
                            m = 0;
                        
                        instancemercadona.transform.SetParent(boardHolder2);
                        break;

                    case '0':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case '1':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case '2':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case '3':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;

                    case '4':
                        instance = Instantiate(carretera[Int32.Parse(ch.ToString())], new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
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
                        instance = Instantiate(acera, new Vector3(xmapa, ymapa, 0f), Quaternion.identity);
                        break;
                }
                instance.transform.SetParent(boardHolder);
            }
        }

        for (int pl = 0; pl < ptotal; pl++)
        {
            char ch = jugadores[pl + 1][0];
            GameObject instance;
            switch (ch)
            {
                case 'P':
                    instance = Instantiate(player, new Vector3(Convert.ToInt32(jugadores[pl+1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    break;

                case 'V':
                    instance = Instantiate(enemigov, new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    break;

                case 'H':
                    instance = Instantiate(enemigoh, new Vector3(Convert.ToInt32(jugadores[pl + 1].Split(' ')[1]), Convert.ToInt32(jugadores[pl + 1].Split(' ')[2]), 0f), Quaternion.identity);
                    break;
            }
            //instance.transform.SetParent(boardHolder4);
        }
    }
}
        
    