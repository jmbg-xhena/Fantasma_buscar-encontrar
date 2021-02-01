using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonesDePresion : MonoBehaviour
{
    public bool activado = false;
    public bool presionado = false;

    public SpriteRenderer spriteRenderer;

    public Sprite yaPresionado;
    public Sprite sinPresionar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activado == false)
        {
            print("Entra");
            if (collision.gameObject.CompareTag("Aron") || collision.gameObject.CompareTag("Amelia") || collision.gameObject.CompareTag("piedra"))
            {
                presionado = true;
                spriteRenderer.sprite = yaPresionado;
                print("Entra x2");

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (activado == false)
        {
            print("Sale");

            if (collision.gameObject.CompareTag("Aron") || collision.gameObject.CompareTag("Amelia") || collision.gameObject.CompareTag("piedra"))
            {
                presionado = false;
                spriteRenderer.sprite = sinPresionar;
                print("Sale x2");

            }
        }
    }


}
