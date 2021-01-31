using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampa : MonoBehaviour
{
    Animator anim;
    Animation cerrar_clip;

    bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        anim = gameObject.GetComponent<Animator>();
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
            if (collision.transform.CompareTag("Aron"))
            {
                anim.SetBool("Hit", true);
                //Mata a Aron
            }
            else if (collision.transform.CompareTag("Amelia"))
            {
                if (collision.gameObject.GetComponent<humano>().stick == true)
                {
                    collision.gameObject.GetComponent<humano>().stick = false;
                }
                else
                {
                    anim.SetBool("Hit", true);
                    //mata a Amelia
                }
            }
        }
    }
}
