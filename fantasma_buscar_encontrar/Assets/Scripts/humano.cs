using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class humano : MonoBehaviour
{
    [Header("inventario")]
    public int no_llaves;
    public int no_paginas;
    public bool stick = false;
    public bool stone = false;
    [Header("animacion")]
    private Animator anim;
    public GameObject hbox;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactivateAtack()
    {
        anim.SetBool("IsAttacking", false);
        hbox.SetActive(false);
    }

    public void activateHitbox()
    {
        hbox.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("trampa"))
        {
            if (stick == false)
            {
                print("humano game over");
            }
            else {
                Destroy(collision.gameObject);
            }
        }


        if (collision.transform.CompareTag("lobo"))
        {
            print("humano game over");
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("stick"))
        {
            if()
        }
    }*/
}
