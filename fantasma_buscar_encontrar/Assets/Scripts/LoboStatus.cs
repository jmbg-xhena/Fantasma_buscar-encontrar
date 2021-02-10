using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoboStatus : MonoBehaviour
{
    public float t = 0;
    public bool chocando;
    public float xScale;
    public float velocidad = 1;
    public bool scared = false;

    public Transform posAron;
    public Transform posAmelia;

    void Start()
    {
        posAron = GameObject.FindGameObjectWithTag("Aron").transform;
        posAmelia = GameObject.FindGameObjectWithTag("Amelia").transform;
        xScale = transform.localScale.x;
        t = 0;

    }

    private void Update()
    {
        if (scared == true)
        {
            if (!chocando)
            {
                if (transform.position.x < posAron.transform.position.x)
                {
                    this.GetComponent<SpriteRenderer>().flipX = false;
                }
                else if (transform.position.x > posAron.transform.position.x)
                {
                    this.GetComponent<SpriteRenderer>().flipX = true;
                }
                t = 0.01f * velocidad;
                transform.position = Vector3.MoveTowards(transform.position, -posAron.transform.position, t);
            }
        }
        else if (scared == false)
        {
            if (!chocando)
            {
                if (transform.position.x < posAmelia.transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else if (transform.position.x > posAmelia.transform.position.x)
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                t = 0.01f * velocidad;
                transform.position = Vector3.MoveTowards(transform.position, posAmelia.transform.position, t);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("arma_aron"))
        {
            StartCoroutine(WaitToKill());
            scared = true;
        }
        if (collision.transform.CompareTag("Amelia"))
        {
            chocando = true;
            gameObject.GetComponent<Animator>().SetBool("Attacking", true);
            collision.gameObject.GetComponent<Animator>().SetTrigger("dead");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Amelia"))
        {
            chocando = false;
            gameObject.GetComponent<Animator>().SetBool("Attacking", false);
        }
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }

    IEnumerator WaitToKill()
    {
        yield return new WaitForSeconds(4f);
        destroy();
    }
}
