using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampa : MonoBehaviour
{
    Animator anim;
    Animation cerrar_clip;
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
        if (collision.transform.CompareTag("Amelia") || collision.transform.CompareTag("Aron"))
        {
            gameObject.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.None;
            anim.SetBool("Activate", true);
        }
        if(collision.transform.CompareTag("Aron"))
        {
            anim.SetBool("Hit", true);
        }
    }
}
