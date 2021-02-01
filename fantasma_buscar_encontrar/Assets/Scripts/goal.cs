using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("recursos para recolectar")]
    public int llaves_necesarias;
    public int paginas_necesarias;
    private humano player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Aron")) {
            player = collision.GetComponent<humano>();
            if (llaves_necesarias == player.no_llaves && paginas_necesarias == player.no_paginas) {
                print("cambiar de nivel");
            }
        }
    }
}
