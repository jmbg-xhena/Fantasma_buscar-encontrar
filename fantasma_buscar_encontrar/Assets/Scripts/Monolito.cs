using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolito : MonoBehaviour
{
    public bool monolitoDeAmelia;
    public bool isActivated = false;
    public SpriteRenderer spriteRenderer;

    public Sprite spriteMonolito;
    public Sprite spriteMonolitoActivado;
    public Sprite spriteMonolitoAron;
    public Sprite spriteMonolitoAmelia;

    WaitForSeconds desactivarMonolito = new WaitForSeconds(2f);
    WaitForSeconds parpadeoMonolito = new WaitForSeconds(.4f);

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (monolitoDeAmelia == true)
        {
            if (collision.CompareTag("arma_amelia"))
            {
                isActivated = true;
                spriteRenderer.sprite = spriteMonolitoAmelia;

            } 
            else if (collision.CompareTag("arma_aron"))
            {
                spriteRenderer.sprite = spriteMonolitoAmelia;
            }
        } 
        else
        {
            if (collision.CompareTag("arma_aron"))
            {
                isActivated = true;
                spriteRenderer.sprite = spriteMonolitoAron;

            }
            else if (collision.CompareTag("arma_amelia"))
            {
                spriteRenderer.sprite = spriteMonolitoAron;

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (monolitoDeAmelia == true)
        {
            if (collision.CompareTag("arma_amelia"))
            {
                isActivated = true;
                spriteRenderer.sprite = spriteMonolitoAmelia;

            }
            else if (collision.CompareTag("arma_aron"))
            {
                spriteRenderer.sprite = spriteMonolitoAmelia;
            }
        }
        else
        {
            if (collision.CompareTag("arma_aron"))
            {
                isActivated = true;
                spriteRenderer.sprite = spriteMonolitoAron;

            }
            else if (collision.CompareTag("arma_amelia"))
            {
                spriteRenderer.sprite = spriteMonolitoAron;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isActivated == true)
        {
            StartCoroutine(Desactivar());
        }
        else
        {
            spriteRenderer.sprite = spriteMonolito;
        }

    }

    IEnumerator Desactivar()
    {
        StartCoroutine(Parpadeo());
        yield return desactivarMonolito;
        isActivated = false;
    }

    IEnumerator Parpadeo()
    {
        if(isActivated == true)
        {
            if (monolitoDeAmelia == true)
            {
                if (spriteRenderer.sprite == spriteMonolito || spriteRenderer.sprite == spriteMonolitoActivado)
                {
                    spriteRenderer.sprite = spriteMonolitoAmelia;
                }
                else
                {
                    spriteRenderer.sprite = spriteMonolitoActivado;
                }
            }
            else
            {
                if (spriteRenderer.sprite == spriteMonolito || spriteRenderer.sprite == spriteMonolitoActivado)
                {
                    spriteRenderer.sprite = spriteMonolitoAron;
                }
                else
                {
                    spriteRenderer.sprite = spriteMonolitoActivado;

                }
            }
            yield return parpadeoMonolito;
            StartCoroutine(Parpadeo());

        }
        else
        {
            spriteRenderer.sprite = spriteMonolito;
            yield return parpadeoMonolito;

        }
    }




}
