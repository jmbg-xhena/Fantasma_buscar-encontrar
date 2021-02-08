﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espectro : MonoBehaviour
{
    public float t = 0;
    public bool chocando;
    public float xScale;
    // Start is called before the first frame update
    void Start()
    {
        xScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("arma_amelia"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("muerto");
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Aron"))
        {
            chocando = true;
            gameObject.GetComponent<Animator>().SetBool("Consuming", true);
            collision.gameObject.GetComponent<Animator>().SetTrigger("dead");
        }
    }

    public void destroy()
    {
        Destroy(this.gameObject);   
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Aron"))
        {
            chocando = false;
            gameObject.GetComponent<Animator>().SetBool("Consuming", false);
        }
    }
}
