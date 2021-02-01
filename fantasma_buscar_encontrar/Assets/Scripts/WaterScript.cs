using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("awa"))
        {
            anim.SetBool("Water", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("awa"))
        {
            anim.SetBool("Water", false);
        }
    }
}
