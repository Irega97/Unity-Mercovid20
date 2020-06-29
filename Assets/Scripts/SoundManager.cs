using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;
    public AudioSource musica;
    public AudioClip fondo;
    public AudioClip contagiado;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void contagiar()
    {
        musica.clip = contagiado;
        musica.Play();
    }

    public void curar()
    {
        musica.clip = fondo;
        musica.Play();
    }

    public void gameover()
    {
        if (!GameManager.instance.contagio)
        {
            musica.clip = contagiado;
            musica.Play();
        }
    }
}
