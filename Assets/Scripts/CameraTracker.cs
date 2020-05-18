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
    
    // Update is called once per frame
    void Update()
    {
        if (player == null)
            player = GameObject.Find("Jugador(Clone)");

        else if (player != null)
        {
            x = player.transform.position.x;
            y = player.transform.position.y;

            if (x < -24.5)
                x = -24.5f;
            else if (x > 25.5)
                x = 25.5f;

            if (y < -25.5)
                y = -25.5f;

            else if (y > 24.5)
                y = 24.5f;

            transform.position = new Vector3(x, y, -10);
        }
    }

    
}
