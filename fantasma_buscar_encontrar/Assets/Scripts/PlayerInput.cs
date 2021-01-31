using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    private humano P1Script;
    private fantasma P2Script;
    public float coolDownAcciones = 0.1f;
    public InputAction Input_moveP1;
    public InputAction Input_accionP1;
    public InputAction Input_interaccionP1;
    private bool CanAccionP1;
    public Vector3 moveValuesP1;
    public InputAction Input_moveP2;
    public InputAction Input_accionP2;
    private bool CanAccionP2;
    private Vector3 moveValuesP2;
    public float velocidadMovimiento = 1.0f;
    private GameObject hitboxP1;
    private GameObject hitboxP2;

    private Animator P1anim;
    private Animator P2anim;

    private void OnEnable()
    {
        Input_moveP1.Enable();
        Input_moveP2.Enable();
        Input_accionP1.Enable();
        Input_accionP2.Enable();
        Input_interaccionP1.Enable();

    }

    private void OnDisable()
    {
        Input_moveP1.Disable();
        Input_moveP2.Disable();
        Input_accionP1.Disable();
        Input_accionP2.Disable();
        Input_interaccionP1.Disable();

    }

    // Start is called before the first frame update
    void Start()
    {
        CanAccionP1 = true;
        CanAccionP2 = true;
        P1= GameObject.FindGameObjectWithTag("Amelia");
        P2 = GameObject.FindGameObjectWithTag("Aron");
        P1Script = P1.GetComponent<humano>();
        P2Script = P2.GetComponent<fantasma>();
        P1anim = P1.GetComponent<Animator>();
        P2anim = P2.GetComponent<Animator>();
        hitboxP1 = P1.GetComponentInChildren<hitbox>().gameObject;
        hitboxP2 = P2.GetComponentInChildren<hitbox>().gameObject;
        hitboxP1.SetActive(false);
        hitboxP2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ///inputs
            //moverse humano
        moveValuesP1 = new Vector3(Input_moveP1.ReadValue<Vector2>().x, Input_moveP1.ReadValue<Vector2>().y, 0f);
        P1.transform.position += moveValuesP1 * (velocidadMovimiento * Time.deltaTime);
        rotatePersonaje(P1anim, moveValuesP1,hitboxP1);

            //moverse fantasma
        moveValuesP2 = new Vector3(Input_moveP2.ReadValue<Vector2>().x, Input_moveP2.ReadValue<Vector2>().y, 0f);
        P2.transform.position += moveValuesP2 * (velocidadMovimiento * Time.deltaTime);
        rotatePersonaje(P2anim, moveValuesP2,hitboxP2);

            //destruir trampas
        if (Input_accionP1.ReadValue<float>()==1&&CanAccionP1) {
            CanAccionP1 = false;
            P1anim.SetBool("IsAttacking", true);
            print("ataque rama/piedra");
            Invoke("activarAccionP1",coolDownAcciones);
        }
        if (Input_accionP2.ReadValue<float>() == 1 && CanAccionP2)
        {
            CanAccionP2 = false;
            P2anim.SetBool("IsAttacking", true);
            //activar ataque mágico;
            print("ataque magico");
            Invoke("activarAccionP2", coolDownAcciones);
            
        }
        if (Input_interaccionP1.ReadValue<float>() == 1 && CanAccionP1)
        {
            CanAccionP1 = false;
            print("Interaccion");
            Invoke("activarAccionP1", coolDownAcciones);
            P1.GetComponent<humano>().agarrarObjeto = true;
            StartCoroutine(deactivateAction());
        }
        if (P1.GetComponent<humano>().stick == true)
        {
            P1anim.SetBool("Stick", true);
        }
        else if (P1.GetComponent<humano>().stone == true)
        {
            P1anim.SetBool("Stone", true);

        }
        else if (P1.GetComponent<humano>().stick == false)
        {
            P1anim.SetBool("Stick", false);
        }
        else if (P1.GetComponent<humano>().stone == false)
        {
            P1anim.SetBool("Stone", false);

        }

        ///


    }

    void activarAccionP1() {
        //P1Script.rama.SetActive(false);
        CanAccionP1 = true;
    }
    void activarAccionP2()
    {
        //P1Script.rama.SetActive(false);
        CanAccionP2 = true;
    }

    IEnumerator deactivateAction()
    {
        yield return new WaitForSeconds(.15f);
        P1.GetComponent<humano>().agarrarObjeto = false;
    }


    //rotar personajes dependiendo de la diercción de movimiento
    void rotatePersonaje(Animator anim, Vector3 moveValues, GameObject hbox) {
        anim.SetFloat("SpeedX", moveValues.x);
        anim.SetFloat("SpeedY", moveValues.y);
        if (moveValues.x != 0 || moveValues.y != 0)
        {
            anim.SetBool("IsMoving", true);
        }
        else {
            anim.SetBool("IsMoving", false);
        }

        if (moveValues == Vector3.up)
        {
            
            anim.SetInteger("IsLookingAt", 1);
            if (!hbox.CompareTag("arma_aron"))
            {
                hbox.transform.rotation = Quaternion.Euler(new Vector3(hbox.transform.rotation.x, hbox.transform.rotation.y, 0f));

            }
        }
        if (moveValues == Vector3.down)
        {
            anim.SetInteger("IsLookingAt", 3);
            if (!hbox.CompareTag("arma_aron"))
            {
                hbox.transform.rotation = Quaternion.Euler(new Vector3(hbox.transform.rotation.x, hbox.transform.rotation.y, 180f));

            }
        }
        if (moveValues == Vector3.left)
        {
            anim.SetInteger("IsLookingAt", 2);
            if (!hbox.CompareTag("arma_aron"))
            {
                hbox.transform.rotation = Quaternion.Euler(new Vector3(hbox.transform.rotation.x, hbox.transform.rotation.y, 90f));

            }
        }
        if (moveValues == Vector3.right)
        {
            anim.SetInteger("IsLookingAt", 4);
            if (!hbox.CompareTag("arma_aron"))
            {
                hbox.transform.rotation = Quaternion.Euler(new Vector3(hbox.transform.rotation.x, hbox.transform.rotation.y, -90f));

            }
        }
        if (moveValues.x>0 && moveValues.x < 1 && moveValues.y > 0 && moveValues.y < 1)
        {
            if (!hbox.CompareTag("arma_aron"))
            {
                hbox.transform.rotation = Quaternion.Euler(new Vector3(hbox.transform.rotation.x, hbox.transform.rotation.y, -45f));

            }
        }
        if (moveValues.x < 0 && moveValues.x > -1 && moveValues.y > 0 && moveValues.y < 1)
        {
            if (!hbox.CompareTag("arma_aron"))
            {
                hbox.transform.rotation = Quaternion.Euler(new Vector3(hbox.transform.rotation.x, hbox.transform.rotation.y, 45f));

            }
        }
        if (moveValues.x < 0 && moveValues.x > -1 && moveValues.y < 0 && moveValues.y > -1)
        {
            if (!hbox.CompareTag("arma_aron"))
            {
            hbox.transform.rotation = Quaternion.Euler(new Vector3(hbox.transform.rotation.x, hbox.transform.rotation.y, 135f));

            }
        }
        if (moveValues.x > 0 && moveValues.x < 1 && moveValues.y < 0 && moveValues.y > -1)
        {
            if (!hbox.CompareTag("arma_aron"))
            {
                hbox.transform.rotation = Quaternion.Euler(new Vector3(hbox.transform.rotation.x, hbox.transform.rotation.y, -135));

            }
        }
    }
}
