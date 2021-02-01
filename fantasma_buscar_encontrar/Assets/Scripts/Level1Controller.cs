using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour
{
    public Monolito monolitoAron;
    public Monolito monolitoAmelia;

    public BotonesDePresion boton1;
    public BotonesDePresion boton2;

    public Puerta puerta1;
    public Puerta puertaSalida;

    void Update()
    {
        if (monolitoAmelia.activadoFinal == false)
        {
            ActivadoDeMonolitos();
        }

        if(boton1.activado == false)
        {
            ActivadoDeBotones();
        }
        
    }

    void ActivadoDeMonolitos()
    {
        if(monolitoAmelia.isActivated == true && monolitoAron.isActivated == true)
        {
            monolitoAron.activadoFinal = true;
            monolitoAmelia.activadoFinal = true;

            puerta1.activate = true;
        }
    }

    void ActivadoDeBotones()
    {
        if (boton1.presionado == true && boton2.presionado == true)
        {
            boton1.activado = true;
            boton2.activado = true;

            puertaSalida.activate = true;
        }
    }

}
