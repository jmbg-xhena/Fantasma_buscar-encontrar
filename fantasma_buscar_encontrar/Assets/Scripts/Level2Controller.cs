using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour
{
    public Monolito monolitoAron;
    public Monolito monolitoAmelia;

    public BotonesDePresion boton1;
    public BotonesDePresion boton2;

    public BotonesDePresion boton3;
    public BotonesDePresion boton4;

    public BotonesDePresion boton5;
    public BotonesDePresion boton6;

    public BotonesDePresion boton7;
    public BotonesDePresion boton8;


    public Puerta puerta1;
    public Puerta puerta2;

    public PuertaAbierta puertaAbierta1;
    public PuertaAbierta puertaAbierta2;


    public Puerta puerta3;

    public Puerta puerta4;

    public Puerta puerta5;


    public Trigger trigger1;
    public Trigger trigger2;
    public Trigger trigger3;
    public Trigger trigger4;

    public bool firstActivatedTrigger1;
    public bool firstActivatedTrigger2;
    public bool firstActivatedTrigger3;
    public bool firstActivatedTrigger4;

    public GameObject terrenoCambiado;
    public GameObject terrenoNormal;

    public GameObject lobo1;
    public GameObject lobo2;


    void Update()
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

        if (boton5.activado == false)
        {
            ActivadoDeBotones3();
        }

        if (boton7.activado == false)
        {
            ActivadoDeBotones4();
        }

        if (trigger1.alreadyUsed == false)
        {
            TriggerAccion1();
        }

        if (trigger2.alreadyUsed == false)
        {
            TriggerAccion2();
        }

        if (trigger3.alreadyUsed == false)
        {
            TriggerAccion3();
        }

        if (trigger4.alreadyUsed == false)
        {
            TriggerAccion4();
        }


    }

    void ActivadoDeMonolitos()
    {
        if (monolitoAmelia.isActivated == true && monolitoAron.isActivated == true)
        {
            monolitoAron.activadoFinal = true;
            monolitoAmelia.activadoFinal = true;

            puerta1.activate = true;
            puerta2.activate = true;

            puertaAbierta1.activate = true;
            puertaAbierta2.activate = true;
        }
    }

    void ActivadoDeBotones1()
    {
        if (boton1.presionado == true && boton2.presionado == true)
        {
            boton1.activado = true;
            boton2.activado = true;

            terrenoCambiado.SetActive(true);
            terrenoNormal.SetActive(false);
        }
    }

    void ActivadoDeBotones2()
    {
        if (boton3.presionado == true && boton4.presionado == true)
        {
            boton3.activado = true;
            boton4.activado = true;

            puerta3.activate = true;
        }
    }

    void ActivadoDeBotones3()
    {
        if (boton5.presionado == true && boton6.presionado == true)
        {
            boton5.activado = true;
            boton6.activado = true;

            puerta4.activate = true;
        }
    }

    void ActivadoDeBotones4()
    {
        if (boton7.presionado == true && boton8.presionado == true)
        {
            boton7.activado = true;
            boton8.activado = true;

            puerta5.activate = true;
        }
    }

    void TriggerAccion1()
    {
        if (trigger1.firstActivated == true)
        {
            /*lobo1.SetActive(true);
            lobo2.SetActive(true);*/

            terrenoNormal.SetActive(true);
            terrenoCambiado.SetActive(false);

            trigger1.alreadyUsed = true;
        }
    }

    void TriggerAccion2()
    {
        if (trigger2.firstActivated == true)
        {
            terrenoCambiado.SetActive(true);
            terrenoNormal.SetActive(false);

            trigger2.alreadyUsed = true;
        }
    }

    void TriggerAccion3()
    {
        if (trigger3.firstActivated == true)
        {

            if (terrenoCambiado.gameObject.activeInHierarchy == true)
            {
                terrenoNormal.SetActive(true);
                terrenoCambiado.SetActive(false);
            }
            else if (terrenoCambiado.gameObject.activeInHierarchy == false)
            {
                terrenoNormal.SetActive(false);
                terrenoCambiado.SetActive(true);
            }

            trigger3.alreadyUsed = true;
        }
    }

    void TriggerAccion4()
    {
        if (trigger4.firstActivated == true)
        {
            if (terrenoCambiado.gameObject.activeInHierarchy == true)
            {
                terrenoNormal.SetActive(true);
                terrenoCambiado.SetActive(false);
            }
            else if (terrenoCambiado.gameObject.activeInHierarchy == false)
            {
                terrenoNormal.SetActive(false);
                terrenoCambiado.SetActive(true);
            }

            trigger4.alreadyUsed = true;
        }
    }

}
