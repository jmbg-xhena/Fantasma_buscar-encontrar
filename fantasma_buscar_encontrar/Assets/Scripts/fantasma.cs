using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantasma : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void deactivateAtack() {
        anim.SetBool("IsAttacking", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("espectro"))
        {
            print("fantasma game over");
        }
    }
}
