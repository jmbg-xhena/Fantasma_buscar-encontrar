using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class humano : MonoBehaviour
{
    public PlayerInput Pinput;
    [Header("inventario")]
    public int no_llaves;
    public int no_paginas;
    public bool stick = false;
    public bool stone = false;

    public bool agarrarObjeto = false;



    public AudioSource aud;
    public AudioClip[] hierba;
    public AudioClip[] camino;
    public AudioClip wMovement;
    public AudioClip wSplash;
    public float frecuencia_pasos = 0.1f;//frecuencia en la que se va a reproducir el sonido de los pasos
    public bool caminando = false;
    private int index_random = 0;
    public string terreno = "";

    [Header("animacion")]
    private Animator anim;
    public GameObject hbox;
    // Start is called before the first frame update
    void Start()
    {
        Pinput = GameObject.FindGameObjectWithTag("Pcontroler").GetComponent<PlayerInput>();
        aud= GameObject.FindGameObjectWithTag("Lcontroler").GetComponent<AudioSource>();
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
                Pinput.velocidadMovimiento = 0;
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
            Pinput.velocidadMovimiento = 0;
        }

        if (collision.transform.CompareTag("lobo"))
        {
            print("humano game over");
            Pinput.velocidadMovimiento = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("camino"))
        {
            index_random = Random.Range(0, 3);
            aud.PlayOneShot(camino[index_random]);
        }
        if (collision.transform.CompareTag("hierba"))
        {
            index_random = Random.Range(0, 3);
            aud.PlayOneShot(hierba[index_random]);
        }
        if (collision.transform.CompareTag("awa"))
        {
            aud.volume = 0.05f;
            aud.PlayOneShot(wSplash);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Pinput.Input_moveP1.ReadValue<Vector2>().x != 0 || Pinput.Input_moveP1.ReadValue<Vector2>().y != 0)
        {
            if (collision.transform.CompareTag("camino"))
            {
                frecuencia_pasos = 0.5f;
                if (!caminando)
                {
                    aud.volume = 1f;
                    caminando = true;
                    index_random = Random.Range(0, 3);
                    aud.PlayOneShot(camino[index_random]);
                    CancelInvoke("darPaso");
                    Invoke("darPaso", frecuencia_pasos);
                }
            }
            if (collision.transform.CompareTag("hierba"))
            {
                frecuencia_pasos = 0.65f;
                if (!caminando)
                {
                    aud.volume = 1f;
                    caminando = true;
                    index_random = Random.Range(0, 3);
                    aud.PlayOneShot(hierba[index_random]);
                    Invoke("darPaso", frecuencia_pasos);
                }
            }
            if (collision.transform.CompareTag("awa"))
            {
                aud.volume = 0.1f;
                frecuencia_pasos = 2f;
                if (!caminando)
                {
                    caminando = true;
                    aud.PlayOneShot(wMovement);
                    Invoke("darPaso", frecuencia_pasos);
                }
            }
        }
        else
        {

        }
    }

    public void darPaso()
    {
        caminando = false;
    }


}
