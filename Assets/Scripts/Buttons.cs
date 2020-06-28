using System.Collections;
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
    public Text estadoVida;
    private Text desinfectante;
    private Text desinfectanteplus;
    private Text desinfectantepro;
    private Text jabon;


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

        estadoVida = GameObject.Find("EstadoText").GetComponent<Text>();
        desinfectante = GameObject.Find("DesinfectanteText").GetComponent<Text>();
        desinfectanteplus = GameObject.Find("DesinfectantePlusText").GetComponent<Text>();
        desinfectantepro = GameObject.Find("DesinfectanteProText").GetComponent<Text>();
        jabon = GameObject.Find("JabonText").GetComponent<Text>();

        desinfectante.text = "x" + cantidadDesinfectante;
        desinfectanteplus.text = "x" + cantidadDesinfectantePlus;
        desinfectantepro.text = "x" + cantidadDesinfectantePro;
        jabon.text = "x" + cantidadJabon;
    }

    public void Desinfectante ()
    {
        if( cantidadDesinfectante > 0)
        {
            if (player.health < 100)
            {
                estadoVida.text = " + 10 de vida! ";
                player.health = player.health + 10;
                if (player.health > 100)
                    player.health = 100;
                estadoVida.text = "Vida: " + player.health;
            }
            
            cantidadDesinfectante--;
            GameManager.instance.cantidadDesinfectante--;
            desinfectante.text = "x" + cantidadDesinfectante;
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
            if (player.health < 100)
            {
                estadoVida.text = " + 25 de vida! ";
                player.health = player.health + 25;
                if (player.health > 100)
                    player.health = 100;
                estadoVida.text = "Vida: " + player.health;
            }

            GameManager.instance.cantidadDesinfectantePlus--;
            cantidadDesinfectantePlus--;
            desinfectanteplus.text = "x" + cantidadDesinfectantePlus;
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
            if (player.health < 100)
            {
                estadoVida.text = " + 50 de vida! ";
                player.health = player.health + 50;
                if (player.health > 100)
                    player.health = 100;
                estadoVida.text = "Vida: " + player.health;
            }
            GameManager.instance.cantidadDesinfectantePro--;
            cantidadDesinfectantePro--;
            desinfectantepro.text = "x" + cantidadDesinfectantePro;
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
                estadoVida.text = " ¡Te has curado del contagio! ";
                estadoVida.text = "Vida: " + player.health;
                player.contagiado = false;
            }

            GameManager.instance.cantidadJabon--;
            cantidadJabon--;
            jabon.text = "x" + cantidadJabon;
        }
        else
        {
            estadoVida.text = " No te queda más Jabón ";
            estadoVida.text = "Vida: " + player.health;
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
