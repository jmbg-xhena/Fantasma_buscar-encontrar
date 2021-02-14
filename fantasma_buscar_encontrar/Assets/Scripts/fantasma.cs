using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fantasma : MonoBehaviour
{
    public PlayerInput Pinput;
    private Animator anim;
    public GameObject hbox;
    public AudioSource aud;
    public AudioClip[] hierba;
    public AudioClip[] camino;
    public float frecuencia_pasos = 0.1f;//frecuencia en la que se va a reproducir el sonido de los pasos
    public bool caminando=false;
    private int index_random = 0;
    public string terreno="";

    public SpriteRenderer spriteRenderer;

    Color linternaAzul = new Color(0, 255, 245, 0.12549f);
    Color linternaBlanca= new Color(255, 255, 255, 0.12549f);

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Pinput = GameObject.FindGameObjectWithTag("Pcontroler").GetComponent<PlayerInput>();
        aud = GameObject.FindGameObjectWithTag("Lcontroler").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deactivateAtack() {
        anim.SetBool("IsAttacking", false);
        hbox.SetActive(false);

        spriteRenderer.color = linternaAzul;

    }

    public void activateHitbox()
    {
        hbox.SetActive(true);

        spriteRenderer.color = linternaBlanca;
    }

    public void reload_scene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("trampa") && collision.gameObject.GetComponent<trampa>().impactoConPiedra == false || collision.transform.CompareTag("trampaUp") && collision.gameObject.GetComponent<trampa>().impactoConPiedra == false || collision.transform.CompareTag("trampaDown") && collision.gameObject.GetComponent<trampa>().impactoConPiedra == false)
        {
            anim.SetTrigger("dead");
        }
        if (collision.transform.CompareTag("vacio")) {
            anim.SetTrigger("fall");
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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Pinput.Input_moveP2.ReadValue<Vector2>().x != 0 || Pinput.Input_moveP2.ReadValue<Vector2>().y != 0)
        {
            if (collision.transform.CompareTag("camino"))
            {
                frecuencia_pasos = 0.5f;
                if (!caminando)
                {
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
                    caminando = true;
                    index_random = Random.Range(0, 3);
                    aud.PlayOneShot(hierba[index_random]);
                    Invoke("darPaso", frecuencia_pasos);
                }
            }
        }
        else {
            
        }
    }

    public void darPaso() {
        caminando = false;
    }
}
