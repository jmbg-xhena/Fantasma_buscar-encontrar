using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espectro : MonoBehaviour
{
    public float t = 0;
    public bool chocando;
    public float xScale;
    public float velocidad = 1;

    public AudioClip muerte;
    public AudioClip ataque;


    private AudioSource audioEspectro;


    void Start()
    {
        xScale = transform.localScale.x;
        audioEspectro = GetComponent<AudioSource>();
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("arma_amelia"))
        {
            gameObject.GetComponent<Animator>().SetTrigger("muerto");
            audioEspectro.clip = muerte;
            audioEspectro.Play();
        }
        if (collision.transform.CompareTag("Aron"))
        {
            collision.gameObject.GetComponent<fantasma>().Pinput.velocidadMovimiento = 0;
            chocando = true;
            gameObject.GetComponent<Animator>().SetBool("Consuming", true);
            collision.gameObject.GetComponent<Animator>().SetTrigger("dead");
            audioEspectro.clip = ataque;
            audioEspectro.Play();

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
        StartCoroutine(TiempoDeMuerte());
    }

    IEnumerator TiempoDeMuerte()
    {
        yield return new WaitForSeconds(audioEspectro.time + .1f);
        Destroy(this.gameObject);
    }
}
