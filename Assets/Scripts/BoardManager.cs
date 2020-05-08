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
