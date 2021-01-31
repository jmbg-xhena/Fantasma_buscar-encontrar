using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palo : MonoBehaviour
{
    public GameObject parentPalo;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Amelia"))
        {
            if (collision.GetComponent<humano>().agarrarObjeto == true)
            {
                collision.GetComponent<humano>().agarrarObjeto = false;
                collision.GetComponent<humano>().stick = true;
                Destroy(parentPalo.gameObject);
            }
        }
    }
}
