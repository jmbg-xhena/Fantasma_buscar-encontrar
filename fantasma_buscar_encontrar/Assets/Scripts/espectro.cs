using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espectro : MonoBehaviour
{
    public float t = 0;
    private bool chocando;
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
        if (collision.transform.CompareTag("Aron"))
        {
            t = 0;
        }
        if (collision.transform.CompareTag("arma_amelia"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("muerto");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Aron")) {
            if (!chocando)
            {
                print(transform.position.x-collision.transform.position.x);
                if (transform.position.x - collision.transform.position.x < 0) {
                    transform.localScale = new Vector3(xScale, transform.localScale.y, transform.localScale.z);
                }
                if (transform.position.x - collision.transform.position.x > 0)
                {
                    transform.localScale = new Vector3(-xScale, transform.localScale.y, transform.localScale.z);
                }
                t += 0.00008f;
                if (t > 0.001) {
                    t = 0.01f;
                }
                transform.position=Vector3.MoveTowards(transform.position, collision.transform.position, t);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision);
        if (collision.transform.CompareTag("Aron"))
        {
            chocando = true;
            gameObject.GetComponent<Animator>().SetBool("Consuming", true);
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
