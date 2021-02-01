using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piedra : MonoBehaviour
{
    public GameObject parentPiedra;
    public GameObject palo;
    public GameObject instance;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Amelia"))
        {
            if (collision.GetComponent<humano>().agarrarObjeto == true)
            {
                collision.GetComponent<humano>().agarrarObjeto = false;
                collision.GetComponent<humano>().stone = true;
                if (collision.GetComponent<humano>().stick)
                {
                    collision.GetComponent<humano>().stick = false;
                    instance = Instantiate(palo);
                    instance.transform.position = gameObject.transform.position;
                }
                Destroy(parentPiedra.gameObject);
            }
        }
    }
}
