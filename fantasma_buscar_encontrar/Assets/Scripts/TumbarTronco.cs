using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbarTronco : MonoBehaviour
{

    public DireccionTumbar triggerIzquierdo;
    public DireccionTumbar triggerDerecho;
    public DireccionTumbar triggerArriba;
    public DireccionTumbar triggerAbajo;

    public GameObject troncoInferior;
    public GameObject troncoSuperior;

    public Transform transformIzquierdo;
    public Transform transformDerecho;
    public Transform transformArriba;
    public Transform transformAbajo;

    public BoxCollider2D colliderAntes;

    void Update()
    {
        if (triggerIzquierdo.miDireccion == true)
        {
            troncoSuperior.transform.position = transformDerecho.position;
            troncoSuperior.transform.rotation = transformDerecho.rotation;

            colliderAntes.gameObject.SetActive(false);

            troncoSuperior.GetComponent<SpriteRenderer>().sortingOrder = 1;

            troncoInferior.GetComponent<BoxCollider2D>().isTrigger = true;

            triggerIzquierdo.gameObject.SetActive(false);
            triggerDerecho.gameObject.SetActive(false);
            triggerArriba.gameObject.SetActive(false);
            triggerAbajo.gameObject.SetActive(false);
        }
        else if (triggerDerecho.miDireccion == true)
        {
            troncoSuperior.transform.position = transformIzquierdo.position;
            troncoSuperior.transform.rotation = transformIzquierdo.rotation;

            colliderAntes.gameObject.SetActive(false);

            troncoSuperior.GetComponent<SpriteRenderer>().sortingOrder = 1;


            troncoInferior.GetComponent<BoxCollider2D>().isTrigger = true;


            triggerIzquierdo.gameObject.SetActive(false);
            triggerDerecho.gameObject.SetActive(false);
            triggerArriba.gameObject.SetActive(false);
            triggerAbajo.gameObject.SetActive(false);
        }
        else if(triggerArriba.miDireccion == true)
        {
            troncoSuperior.transform.position = transformAbajo.position;
            troncoSuperior.transform.rotation = transformAbajo.rotation;

            colliderAntes.gameObject.SetActive(false);

            troncoSuperior.GetComponent<SpriteRenderer>().sortingOrder = 1;

            troncoInferior.GetComponent<BoxCollider2D>().isTrigger = true;

            triggerIzquierdo.gameObject.SetActive(false);
            triggerDerecho.gameObject.SetActive(false);
            triggerArriba.gameObject.SetActive(false);
            triggerAbajo.gameObject.SetActive(false);
        }
        else if(triggerAbajo.miDireccion == true)
        {
            troncoSuperior.transform.position = transformArriba.position;
            troncoSuperior.transform.rotation = transformArriba.rotation;

            colliderAntes.gameObject.SetActive(false);

            troncoSuperior.GetComponent<SpriteRenderer>().sortingOrder = 1;

            troncoInferior.GetComponent<BoxCollider2D>().isTrigger = true;

            triggerIzquierdo.gameObject.SetActive(false);
            triggerDerecho.gameObject.SetActive(false);
            triggerArriba.gameObject.SetActive(false);
            triggerAbajo.gameObject.SetActive(false);
        }
    }

}
