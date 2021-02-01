using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampa : MonoBehaviour
{
    Animator anim;
    Animation cerrar_clip;

    public GameObject colAmelia;
    public GameObject colAron;

    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        anim = gameObject.GetComponent<Animator>();

        colAmelia = GameObject.FindGameObjectWithTag("Amelia");
        colAron = GameObject.FindGameObjectWithTag("Aron");
    }

    // Update is called once per frame
    void Update()
    {
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

            colAmelia.GetComponent<humano>().stick = false;
            print("destruye palo");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("piedra")) {
            gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            anim.SetBool("Activate", true);
            activated = true;
            collision.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
