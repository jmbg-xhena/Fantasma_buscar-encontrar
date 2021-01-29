using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class humano : MonoBehaviour
{
    [Header("inventario")]
    public int no_llaves;
    public int no_paginas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("trampa"))
        {
            print("humano game over");
        }
        if (collision.transform.CompareTag("lobo"))
        {
            print("humano game over");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("trampa")) {
            Destroy(collision.gameObject);
        }
    }
}
