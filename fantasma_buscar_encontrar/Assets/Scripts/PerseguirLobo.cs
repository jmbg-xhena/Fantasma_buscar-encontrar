using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguirLobo : MonoBehaviour
{
    public LoboStatus miLoboScript;
    public GameObject elLobo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Amelia"))
        {
            miLoboScript.t = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (miLoboScript.scared == false)
        {
            if (collision.transform.CompareTag("Amelia"))
            {
                if (!miLoboScript.chocando)
                {
                    if (transform.position.x < collision.transform.position.x)
                    {
                        elLobo.GetComponent<SpriteRenderer>().flipX = true;
                    }
                    else if (transform.position.x > collision.transform.position.x)
                    {
                        elLobo.GetComponent<SpriteRenderer>().flipX = false;
                    }
                    miLoboScript.t = 1f * miLoboScript.velocidad;
                    elLobo.transform.position = Vector3.MoveTowards(elLobo.transform.position, collision.transform.position, miLoboScript.t);
                }
            }
        }
    }
}
