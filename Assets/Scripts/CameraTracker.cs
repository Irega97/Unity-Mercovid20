using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraTracker : MonoBehaviour
{
    //public Transform trackingTarget;
    public GameObject player;
    float x;
    float y;
    //public GameObject mapa;
    
    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player = GameObject.Find("Jugador(Clone)");

        else if (player != null)
        {
            x = player.transform.position.x;
            y = player.transform.position.y;

            if (x < 4.5f)
                x = 4.5f;

            else if (x > 54.5f)
                x = 54.5f;

            if (y < 4.5f)
                y = 4.5f;

            else if (y > 54.5f)
                y = 54.5f;

            transform.position = new Vector3(x, y, -10);
        }
    }

    
}
