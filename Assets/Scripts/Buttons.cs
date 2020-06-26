using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    Player player = new Player();

    public int cantidadDesinfectante = 3;
    public int cantidadDesinfectantePlus = 3;
    public int cantidadDesinfectantePro = 3;
    public int cantidadJabon = 3;
    public int cantidadMascarilla = 1;
    public int cantidadMegaMascarilla = 1;

    public Text estadoVida;
    private Text desinfectante;
    private Text desinfectanteplus;
    private Text desinfectantepro;
    private Text jabon;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jugador(Clone)").GetComponent<Player>();

        estadoVida = GameObject.Find("EstadoText").GetComponent<Text>();
        desinfectante = GameObject.Find("DesinfectanteText").GetComponent<Text>();
        desinfectanteplus = GameObject.Find("DesinfectantePlusText").GetComponent<Text>();
        desinfectantepro = GameObject.Find("DesinfectanteProText").GetComponent<Text>();
        jabon = GameObject.Find("JabonText").GetComponent<Text>();

        desinfectante.text = "x" + cantidadDesinfectante;
        desinfectanteplus.text = "x" + cantidadDesinfectantePlus;
        desinfectantepro.text = "x" + cantidadDesinfectantePro;
        jabon.text = "x" + cantidadJabon;

        if(cantidadMascarilla > 0 || cantidadMegaMascarilla > 0)
        {
            if(cantidadMegaMascarilla > 0)
            {
                player.health = player.health + 50;
                estadoVida.text = "Vida: " + player.health;
                cantidadMascarilla--;
            }
            else
            {
                player.health = player.health + 25;
                estadoVida.text = "Vida: " + player.health;
                cantidadMascarilla--;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Desinfectante ()
    {
        if( cantidadDesinfectante > 0)
        {
            estadoVida.text = " + 10 de vida! ";
            player.health = player.health + 10;
            estadoVida.text = "Vida: " + player.health;
            desinfectante.text = "x" + --cantidadDesinfectante;
        }
        else
        {
            estadoVida.text = " No te queda más Desinfectante ";
            estadoVida.text = "Vida: " + player.health;
        }
    }

    public void DesinfectantePlus()
    {
        if(cantidadDesinfectantePlus > 0)
        {
            estadoVida.text = " + 25 de vida! ";
            player.health = player.health + 25;
            estadoVida.text = "Vida: " + player.health;
            desinfectanteplus.text = "x" + cantidadDesinfectantePlus--;
        }
        else
        {
            estadoVida.text = " No te queda más Desinfectante Plus ";
            estadoVida.text = "Vida: " + player.health;
        }

    }

    public void DesinfectantePro()
    {
        if (cantidadDesinfectantePro > 0)
        {
            estadoVida.text = " + 50 de vida! ";
            player.health = player.health + 50;
            estadoVida.text = "Vida: " + player.health;
            desinfectantepro.text = "x" + (cantidadDesinfectantePro - 1);
        }
        else
        {
            estadoVida.text = " No te queda más Desinfectante Pro ";
            estadoVida.text = "Vida: " + player.health;
        }

    }

    public void Jabon()
    {
        if (cantidadJabon > 0)
        {
            if (player.contagiado == true)
            {
                estadoVida.text = " Te has curado del contagio! ";
                estadoVida.text = "Vida: " + player.health;
                player.contagiado = false;
                jabon.text = "x" + cantidadJabon--;
            }
            else
                jabon.text = "x" + cantidadJabon--;
        }
        else
        {
            estadoVida.text = " No te queda más Jabón ";
            estadoVida.text = "Vida: " + player.health;
        }
       
    }
}
