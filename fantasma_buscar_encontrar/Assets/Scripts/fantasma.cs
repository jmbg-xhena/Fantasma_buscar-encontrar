using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantasma : MonoBehaviour
{
    private Animator anim;
    public GameObject hbox;

    public SpriteRenderer spriteRenderer;

    Color linternaAzul = new Color(0, 255, 245, 0.12549f);
    Color linternaBlanca= new Color(255, 255, 255, 0.12549f);

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
        hbox.SetActive(false);

        spriteRenderer.color = linternaAzul;

    }

    public void activateHitbox()
    {
        hbox.SetActive(true);

        spriteRenderer.color = linternaBlanca;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("espectro"))
        {
            print("fantasma game over");
        }
    }
}
