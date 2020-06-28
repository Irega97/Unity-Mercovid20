using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip fondo;
    public AudioClip contagiado;
    public AudioSource musica;
    public AudioClip mercadona;
    public static SoundManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void contagio()
    {
        musica.clip = contagiado;
        musica.Play();
    }

    public void quitarcontagio()
    {
        musica.clip = fondo;
        musica.Play();
    }

    public void gameover()
    {
        musica.clip = contagiado;
        musica.Play();   
    }
}
