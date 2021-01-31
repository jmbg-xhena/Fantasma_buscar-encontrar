using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lobo : MonoBehaviour
{
    public float t = 0;
    private bool chocando;
    public float xScale;
    public float initY;
    public bool amelia_entra=false;
    public bool aron_entra = false;
    public Collider2D objeto_col;
    public int direccion=1;
    public bool caminando=true;
    public bool atacando = false;
    public float velocidad;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        xScale = transform.localScale.x;
        initY = transform.position.y;
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, initY, transform.position.z);

        if (!atacando)
        {
            if (caminando)
            {
                transform.position = new Vector3(transform.position.x + velocidad * Time.deltaTime * direccion, transform.position.y, transform.position.z);
            }
            else
            {
                if (aron_entra)
                {
                    if (transform.position.x - objeto_col.transform.position.x < 0)
                    {
                        transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
                        if (direccion > 0)
                        {
                            direccion = -direccion;
                        }
                    }
                    if (transform.position.x - objeto_col.transform.position.x > 0)
                    {
                        transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                        if (direccion < 0)
                        {
                            direccion = -direccion;
                        }
                    }
                    t += 0.00008f;
                    if (t > 0.001)
                    {
                        t = 0.01f;
                    }
                    transform.position = Vector3.MoveTowards(transform.position, objeto_col.transform.position, -t);
                }
                else
                {
                    if (amelia_entra)
                    {
                        if (!chocando)
                        {
                            if (transform.position.x - objeto_col.transform.position.x < 0)
                            {
                                transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                                if (direccion < 0)
                                {
                                    direccion = -direccion;
                                }
                            }
                            if (transform.position.x - objeto_col.transform.position.x > 0)
                            {
                                transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
                                if (direccion > 0)
                                {
                                    direccion = -direccion;
                                }
                            }
                            t += 0.00008f;
                            if (t > 0.001)
                            {
                                t = 0.01f;
                            }
                            transform.position = Vector3.MoveTowards(transform.position, objeto_col.transform.position, t);
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("arma_aron"))
        {
            aron_entra = true;
            objeto_col = collision;
            caminando = false;
        }
        else {
            if (collision.transform.CompareTag("Amelia"))
            {
                amelia_entra = true;
                if (!aron_entra)
                {
                    objeto_col = collision;
                    caminando = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("arma_aron"))
        {
            aron_entra = false;
            caminando = true;
        }
        if (collision.transform.CompareTag("Amelia"))
        {
            amelia_entra = false;
            caminando = true;
        }
    }

    public void deactivateAtack() {
        anim.SetBool("Attacking", false);
        caminando = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Amelia"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("dead");
            anim.SetBool("Attacking", true);
            atacando = true;
            caminando = false;
            velocidad = 0;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        direccion = -direccion;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
}
