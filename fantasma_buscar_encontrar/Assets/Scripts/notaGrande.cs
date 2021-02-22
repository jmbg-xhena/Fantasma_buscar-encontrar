using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notaGrande : MonoBehaviour
{
    private PlayerInput playerInput;
    private bool puedoDesactivarme = false;
    private bool primeraCourutina = false;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();

    }

    // Update is called once per frame
    void Update()
    {
        if(primeraCourutina == false)
        {
            StartCoroutine(TiempoDeEspera());
            primeraCourutina = true;
        }
        if (playerInput.Input_interaccionP1.ReadValue<float>() == 1 && puedoDesactivarme == true)
        {
            print("EntraASalir");
            playerInput.ResumeGame();
            puedoDesactivarme = false;
            primeraCourutina = false;
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator TiempoDeEspera()
    {
        yield return new WaitForSecondsRealtime(.5f);
        print("Puede salir");
        puedoDesactivarme = true;
    }
}
