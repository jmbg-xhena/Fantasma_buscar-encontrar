using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notas : MonoBehaviour
{
    public Image notaGrande;
    private PlayerInput playerInput;


    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Amelia"))
        {
            if (collision.GetComponent<humano>().agarrarObjeto == true)
            {
                collision.GetComponent<humano>().agarrarObjeto = false;
                notaGrande.gameObject.SetActive(true);
                playerInput.PauseGame();

            }
        }
    }
}
