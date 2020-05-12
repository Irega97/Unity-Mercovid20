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

            if (x < -5)
                x = -5;
            else if (x > 5)
                x = 5;

            if (y < -5)
                y = -5;

            else if (y > 5)
                y = 5;

            transform.position = new Vector3(x, y, -10);
        }
    }

    
}
