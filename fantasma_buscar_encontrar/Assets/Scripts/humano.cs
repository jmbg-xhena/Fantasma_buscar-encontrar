using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class humano : MonoBehaviour
{
    [Header("inventario")]
    public int no_llaves;
    public int no_paginas;
    public bool stick = false;
    public bool stone = false;

    public bool agarrarObjeto = false;

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

    public void reload_scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("trampa") && collision.gameObject.GetComponent<trampa>().impactoConPiedra == false || collision.transform.CompareTag("trampaUp") && collision.gameObject.GetComponent<trampa>().impactoConPiedra == false || collision.transform.CompareTag("trampaDown") && collision.gameObject.GetComponent<trampa>().impactoConPiedra == false)
        {
            if (stick == false)
            {
                anim.SetTrigger("dead");
            }
            else {
               Collider2D[] cols = collision.gameObject.transform.parent.gameObject.GetComponentsInChildren<Collider2D>();
                for (int i = 0; i < cols.Length; i++) {
                    cols[i].enabled = false;
                }
            }
        }

        if (collision.transform.CompareTag("vacio"))
        {
            anim.SetTrigger("fall");
        }

        if (collision.transform.CompareTag("lobo"))
        {
            print("humano game over");
        }
    }

    public void AgarrarObjeto()
    {

    }

    
}
