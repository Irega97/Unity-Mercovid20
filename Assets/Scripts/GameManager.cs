using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoardManager boardScript;
    public static GameManager instance = null;
    public int healthPoints = 100;

    void Awake()
    {
        
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);
		boardScript = GetComponent<BoardManager>();
		InitGame();
		
    }


    void InitGame()
    {
        boardScript.SetupScene();
    }

    public void GameOver()
    {
        enabled = false;
    }
}
