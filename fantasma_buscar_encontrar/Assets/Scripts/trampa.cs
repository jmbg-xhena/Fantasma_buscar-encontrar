using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampa : MonoBehaviour
{
    Animator anim;
    Animation cerrar_clip;

    public GameObject colAmelia;
    public GameObject colAron;

    public bool impactoConPiedra = false; 

    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        anim = gameObject.GetComponent<Animator>();

        colAmelia = GameObject.FindGameObjectWithTag("Amelia");
        colAron = GameObject.FindGameObjectWithTag("Aron");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("piedra"))
        {
            impactoConPiedra = true;

            gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            anim.SetBool("Activate", true);
            activated = true;
            if (this.gameObject.CompareTag("trampaDown"))
            {
                StartCoroutine(DestruirPiedra(collision));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(activated == false)
        {

            if (collision.transform.CompareTag("Amelia") || collision.transform.CompareTag("Aron"))
            {
                gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
                anim.SetBool("Activate", true);
                activated = true;
                
            }
            if (collision.transform.CompareTag("Amelia"))
            {
                if (collision.gameObject.GetComponent<humano>().stick == false)
                {

                    anim.SetBool("Hit", true);
                    print("destruye amelia");

                    //mata a Amelia
                }
                else if (collision.gameObject.GetComponent<humano>().stick == true)
                {
                    StartCoroutine(DestruirPalo());

                }
            }
            else if (collision.transform.CompareTag("Aron"))
            {

                anim.SetBool("Hit", true);
                print("destruye aron");
                //Mata a Aron
            }
        }
    }

    IEnumerator DestruirPalo()
    {
        yield return new WaitForSeconds(0.5f);

        if (this.gameObject.CompareTag("trampaDown"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

            colAmelia.GetComponent<humano>().stick = false;
            print("destruye palo");
        }
    }

    IEnumerator DestruirPiedra(Collider2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(collision.GetComponentInParent<Rigidbody2D>().gameObject);

        if (this.gameObject.CompareTag("trampaDown"))
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }

    }

}
