using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireccionTumbar : MonoBehaviour
{
    public bool miDireccion = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Amelia"))
        {
            if (collision.GetComponent<humano>().agarrarObjeto == true)
            {
                collision.GetComponent<humano>().agarrarObjeto = false;

                miDireccion = true;
            }
        }
    }
}
