using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notaGrande : MonoBehaviour
{
    private PlayerInput playerInput;
    private bool puedoDesactivarme = false;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        StartCoroutine(TiempoDeEspera());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInput.Input_interaccionP1.ReadValue<float>() == 1 && puedoDesactivarme == true)
        {
            playerInput.ResumeGame();
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator TiempoDeEspera()
    {
        yield return new WaitForSeconds(.5f);
        puedoDesactivarme = true;
    }
}
