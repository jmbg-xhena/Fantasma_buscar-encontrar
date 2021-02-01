using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Puerta : MonoBehaviour
{
    public bool activate = false;
    public bool once = false;

    private Animator anim;

    private void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (once == false)
        {
            if (activate == true)
            {
                anim.SetBool("Activate", true);
                once = true;
                StartCoroutine(Espera());
            }
        }

    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(1.3f);
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

}
