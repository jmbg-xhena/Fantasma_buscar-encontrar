using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspectroVision : MonoBehaviour
{
    public espectro miEspectroScript;
    public GameObject elEspectro;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Aron"))
        {
            miEspectroScript.t = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Aron"))
        {
            if (!miEspectroScript.chocando)
            {
                if (transform.position.x - collision.transform.position.x < 0)
                {
                    transform.localScale = new Vector3(miEspectroScript.xScale, transform.localScale.y, transform.localScale.z);
                }
                if (transform.position.x - collision.transform.position.x > 0)
                {
                    transform.localScale = new Vector3(-miEspectroScript.xScale, transform.localScale.y, transform.localScale.z);
                }
                miEspectroScript.t = 0.01f * miEspectroScript.velocidad;
                elEspectro.transform.position = Vector3.MoveTowards(elEspectro.transform.position, collision.transform.position, miEspectroScript.t);
            }
        }
    }
}
