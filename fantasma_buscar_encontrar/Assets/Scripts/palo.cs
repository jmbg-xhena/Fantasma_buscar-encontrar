using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palo : MonoBehaviour
{
    public GameObject parentPalo;
    public GameObject piedra;
    public GameObject instance;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Amelia"))
        {
            if (collision.GetComponent<humano>().agarrarObjeto == true)
            {
                collision.GetComponent<humano>().agarrarObjeto = false;
                collision.GetComponent<humano>().stick = true;
                if (collision.GetComponent<humano>().stone) 
                {
                    collision.GetComponent<humano>().stone = false;
                    instance = Instantiate(piedra);
                    instance.transform.position = gameObject.transform.position;
                }
                Destroy(parentPalo.gameObject);
            }
        }
    }
}
