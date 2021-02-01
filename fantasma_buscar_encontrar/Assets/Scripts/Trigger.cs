using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool firstActivated = false;
    public bool alreadyUsed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Amelia") || collision.gameObject.CompareTag("Aron"))
        {
            if (firstActivated == false)
            {
                firstActivated = true;
            }
        }
    }

}
