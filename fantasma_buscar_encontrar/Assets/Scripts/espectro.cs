using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espectro : MonoBehaviour
{
    public float t = 0;
    public bool chocando;
    public float xScale;
    public float velocidad = 1;

    void Start()
    {
        xScale = transform.localScale.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("arma_amelia"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("muerto");
        }
        if (collision.transform.CompareTag("Aron"))
        {
            chocando = true;
            gameObject.GetComponent<Animator>().SetBool("Consuming", true);
            collision.gameObject.GetComponent<Animator>().SetTrigger("dead");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Aron"))
        {
            chocando = false;
            gameObject.GetComponent<Animator>().SetBool("Consuming", false);
        }
    }

    public void destroy()
    {
        Destroy(this.gameObject);
    }

}
