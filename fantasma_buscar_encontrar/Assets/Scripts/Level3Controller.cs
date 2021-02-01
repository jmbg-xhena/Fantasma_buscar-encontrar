using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Controller : MonoBehaviour
{

    public BotonesDePresion boton1;
    public BotonesDePresion boton2;

    public BotonesDePresion boton3;
    public BotonesDePresion boton4;
    public BotonesDePresion boton5;
    public BotonesDePresion boton6;
    public BotonesDePresion boton7;
    public BotonesDePresion boton8;
    public BotonesDePresion boton9;
    public BotonesDePresion boton10;


    public Monolito monolitoAron;
    public Monolito monolitoAmelia;

    public BotonesDePresion boton11;
    public BotonesDePresion boton12;
    public BotonesDePresion boton13;
    public BotonesDePresion boton14;

    public Puerta puerta1;
    public Puerta puerta2;
    public Puerta puerta3;
    public Puerta puerta4;

    public GameObject piedra;

    public GameObject arbol1;
    public GameObject arbol2;

    public BotonesDePresion boton15;
    public BotonesDePresion boton16;

    public int ordenBotones = 0;

    private void Update()
    {
        if (monolitoAmelia.activadoFinal == false)
        {
            ActivadoDeMonolitos();
        }

        if (boton1.activado == false)
        {
            ActivadoDeBotones1();
        }

        if (boton3.activado == false)
        {
            ActivadoDeBotones2();
        }

        if (boton5.activado == false && ordenBotones == 1)
        {
            ActivadoDeBotones3();
        }

        if (boton7.activado == false && ordenBotones == 2)
        {
            ActivadoDeBotones4();
        }

        if (boton9.activado == false && ordenBotones == 3)
        {
            ActivadoDeBotones5();
        }

        if (boton11.activado == false && ordenBotones == 4)
        {
            ActivadoDeBotones6();
        }

        if (boton13.activado == false && ordenBotones == 5)
        {
            ActivadoDeBotones7();
        }

        if (boton15.activado == false)
        {
            ActivadoDeBotones8();
        }



    }

    void ActivadoDeMonolitos()
    {
        if (monolitoAmelia.isActivated == true && monolitoAron.isActivated == true)
        {
            monolitoAron.activadoFinal = true;
            monolitoAmelia.activadoFinal = true;

            puerta3.activate = true;
            puerta4.activate = true;
        }
    }

    void ActivadoDeBotones1()
    {
        if (boton1.presionado == true && boton2.presionado == true)
        {
            boton1.activado = true;
            boton2.activado = true;

            puerta1.activate = true;

        }
    }

    void ActivadoDeBotones2()
    {
        if (boton3.presionado == true && boton4.presionado == true)
        {
            boton3.activado = true;
            boton4.activado = true;

            ordenBotones++;

        }
    }

    void ActivadoDeBotones3()
    {
        if (boton5.presionado == true && boton6.presionado == true)
        {
            boton5.activado = true;
            boton6.activado = true;

            ordenBotones++;

        }
    }

    void ActivadoDeBotones4()
    {
        if (boton7.presionado == true && boton8.presionado == true)
        {
            boton7.activado = true;
            boton8.activado = true;

            ordenBotones++;

        }
    }

    void ActivadoDeBotones5()
    {
        if (boton9.presionado == true && boton10.presionado == true)
        {
            boton9.activado = true;
            boton10.activado = true;

            ordenBotones++;
            puerta2.activate = true;
        }
    }

    void ActivadoDeBotones6()
    {
        if (boton11.presionado == true && boton12.presionado == true)
        {
            boton11.activado = true;
            boton12.activado = true;

            ordenBotones++;
        }
    }

    void ActivadoDeBotones7()
    {
        if (boton13.presionado == true && boton14.presionado == true)
        {
            boton13.activado = true;
            boton14.activado = true;

            piedra.SetActive(false);
            ordenBotones++;
        }
    }

    void ActivadoDeBotones8()
    {
        if (boton15.presionado == true && boton16.presionado == true)
        {
            boton15.activado = true;
            boton16.activado = true;

            arbol1.SetActive(false);
            arbol2.SetActive(false);
        }
    }
}
