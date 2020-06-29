﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    Player player = new Player();

    public int cantidadDesinfectante;
    public int cantidadDesinfectantePlus;
    public int cantidadDesinfectantePro;
    public int cantidadJabon;
    public int cantidadMascarilla;
    public int cantidadMegaMascarilla;
    public Text estadoText;
    public Text vidaText;
    private Text desinfectante;
    private Text desinfectanteplus;
    private Text desinfectantepro;
    private Text jabon;
    AndroidJavaClass javaClass;

    // Start is called before the first frame update
    void Start()
    {
        cantidadDesinfectante = GameManager.instance.cantidadDesinfectante;
        cantidadDesinfectantePlus = GameManager.instance.cantidadDesinfectantePlus;
        cantidadDesinfectantePro = GameManager.instance.cantidadDesinfectantePro;
        cantidadMascarilla = GameManager.instance.cantidadMascarilla;
        cantidadMegaMascarilla = GameManager.instance.cantidadMegaMascarilla;
        cantidadJabon = GameManager.instance.cantidadJabon;
        player = GameObject.Find("Jugador(Clone)").GetComponent<Player>();

        vidaText = GameObject.Find("VidaText").GetComponent<Text>();
        //estadoText = GameObject.Find("").GetComponent<Text>();
        desinfectante = GameObject.Find("DesinfectanteText").GetComponent<Text>();
        desinfectanteplus = GameObject.Find("DesinfectantePlusText").GetComponent<Text>();
        desinfectantepro = GameObject.Find("DesinfectanteProText").GetComponent<Text>();
        jabon = GameObject.Find("JabonText").GetComponent<Text>();

        desinfectante.text = "x" + cantidadDesinfectante;
        desinfectanteplus.text = "x" + cantidadDesinfectantePlus;
        desinfectantepro.text = "x" + cantidadDesinfectantePro;
        jabon.text = "x" + cantidadJabon;
        javaClass = new AndroidJavaClass("edu.upc.login.apiUnity");
    }

    public void Desinfectante ()
    {
        if( cantidadDesinfectante > 0)
        {
            if (player.health < 100)
            {
                vidaText.text = " + 10 de vida! ";
                player.health = player.health + 10;
                if (player.health > 100)
                    player.health = 100;
                vidaText.text = "Vida: " + player.health;
            }
            
            cantidadDesinfectante--;
            GameManager.instance.cantidadDesinfectante--;
            javaClass.CallStatic("setObjetos", 1);
            desinfectante.text = "x" + cantidadDesinfectante;
        }
        else
        {
            //estadoText.text = " No te queda más Desinfectante ";
            vidaText.text = "Vida: " + player.health;
        }
    }

    public void DesinfectantePlus()
    {
        if(cantidadDesinfectantePlus > 0)
        {
            if (player.health < 100)
            {
                //estadoText.text = " + 25 de vida! ";
                player.health = player.health + 25;
                if (player.health > 100)
                    player.health = 100;
                vidaText.text = "Vida: " + player.health;
            }

            GameManager.instance.cantidadDesinfectantePlus--;
            cantidadDesinfectantePlus--;
            javaClass.CallStatic("setObjetos", 2);
            desinfectanteplus.text = "x" + cantidadDesinfectantePlus;
        }
        else
        {
            //estadoText.text = " No te queda más Desinfectante Plus ";
            vidaText.text = "Vida: " + player.health;
        }

    }

    public void DesinfectantePro()
    {
        if (cantidadDesinfectantePro > 0)
        {
            if (player.health < 100)
            {
                //estadoText.text = " + 50 de vida! ";
                player.health = player.health + 50;
                if (player.health > 100)
                    player.health = 100;
                vidaText.text = "Vida: " + player.health;
            }
            GameManager.instance.cantidadDesinfectantePro--;
            cantidadDesinfectantePro--;
            javaClass.CallStatic("setObjetos", 3);
            desinfectantepro.text = "x" + cantidadDesinfectantePro;
        }
        else
        {
            //estadoText.text = " No te queda más Desinfectante Pro ";
            vidaText.text = "Vida: " + player.health;
        }

    }

    public void Jabon()
    {
        if (cantidadJabon > 0)
        {
            if (player.contagiado == true)
            {
                //estadoText.text = " ¡Te has curado del contagio! ";
                vidaText.text = "Vida: " + player.health;
                GameManager.instance.contagio = false;
                player.contagiado = false;
            }

            GameManager.instance.cantidadJabon--;
            cantidadJabon--;
            javaClass.CallStatic("setObjetos", 6);
            jabon.text = "x" + cantidadJabon;
            SoundManager.instance.curar();
        }
        else
        {
            //estadoText.text = " No te queda más Jabón ";
            vidaText.text = "Vida: " + player.health;
        }
       
    }

    public void Restart()
    {
        //aún no hace nada
        Debug.Log("Restart");
    }

    public void Quit()
    {
        //aún no hace nada
        Debug.Log("Quit");
    }
}
