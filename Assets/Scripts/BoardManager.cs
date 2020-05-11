using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject acera;
    private Transform boardHolder;
    public List<GameObject> carretera;
    public GameObject player;

    public void SetupScene()
    {
        GameObject jugador = Instantiate(player, new Vector3(0f, 0f, 0f), Quaternion.identity);
        boardHolder = new GameObject("Board").transform;


        /*string escenario = "          \n" +
                           "          \n" +
                           "   C   C  \n" +
                           "          \n" +
                           "  12345   \n" +
                           "  67890   \n" +
                           "          \n" +
                           "          \n" +
                           "          \n" +
                           "          \n";

        string escenario = "          \n" +
                   "          \n" +
                   "          \n" +
                   "          \n" +
                   "          \n" +
                   "          \n" +
                   "          \n" +
                   "          \n" +
                   "   12345  \n" +
                   "   67890  \n";

        string[] lineas = escenario.Split('\n');

        for(int y=0; y<10; y++)
        {
            string linea = lineas[y];

            for(int x=0; x<10; x++)
            {
                char ch = linea[x];

                GameObject instance;

                switch (ch)
                {

                    case ' ':
                        instance = Instantiate(acera, new Vector3(x, y, 0f), Quaternion.identity);
                        
                        break;
                    case 'P':
                        instance = Instantiate(puerta, new Vector3(x, y, 0f), Quaternion.identity);
                        
                        break;
                    default:
                        instance = Instantiate(acera, new Vector3(x, y, 0f), Quaternion.identity);
                        break;
                }
                instance.transform.SetParent(boardHolder);

        }

        }*/



        for (float x = -49.5f; x < 10.5; x++)
        {
            for (float y = -9.5f; y < 10.5; y++)
            {   
                GameObject instance = Instantiate(acera, new Vector3(x, y, 0f), Quaternion.identity);
                instance.transform.SetParent(boardHolder);
            }
        }
    }
}
