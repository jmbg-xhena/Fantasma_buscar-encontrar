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
    private bool CanAccionP1;
    public Vector3 moveValuesP1;
    public InputAction Input_moveP2;
    public InputAction Input_accionP2;
    private bool CanAccionP2;
    private Vector3 moveValuesP2;
    public float velocidadMovimiento=0.1f;

    private void OnEnable()
    {
        Input_moveP1.Enable();
        Input_moveP2.Enable();
        Input_accionP1.Enable();
        Input_accionP2.Enable();
    }

    private void OnDisable()
    {
        Input_moveP1.Disable();
        Input_moveP2.Disable();
        Input_accionP1.Disable();
        Input_accionP2.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        CanAccionP1 = true;
        CanAccionP2 = true;
        P1Script = P1.GetComponent<humano>();
        P2Script = P2.GetComponent<fantasma>();
    }

    // Update is called once per frame
    void Update()
    {
        ///inputs
            //moverse humano
        moveValuesP1 = new Vector3(Input_moveP1.ReadValue<Vector2>().x, Input_moveP1.ReadValue<Vector2>().y, 0f);
        P1.transform.position += moveValuesP1*velocidadMovimiento;
        //rotatePersonaje(P1, moveValuesP1);

            //moverse fantasma
        moveValuesP2 = new Vector3(Input_moveP2.ReadValue<Vector2>().x, Input_moveP2.ReadValue<Vector2>().y, 0f);
        P2.transform.position += moveValuesP2 * velocidadMovimiento;
        //rotatePersonaje(P2, moveValuesP2);

            //destruir trampas
        if (Input_accionP1.ReadValue<float>()==1&&CanAccionP1) {
            CanAccionP1 = false;
            //P1Script.rama.SetActive(true);
            Invoke("activarAccionP1",coolDownAcciones);
        }
        
        ///


    }

    void activarAccionP1() {
        //P1Script.rama.SetActive(false);
        CanAccionP1 = true;
    }

    //rotar personajes dependiendo de la diercción de movimiento
    /*void rotatePersonaje(GameObject player, Vector3 moveValues) {
        if (moveValues == Vector3.up)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (moveValues == Vector3.down)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (moveValues == Vector3.left)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (moveValues == Vector3.right)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (moveValues.x>0 && moveValues.x < 1 && moveValues.y > 0 && moveValues.y < 1)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        if (moveValues.x < 0 && moveValues.x > -1 && moveValues.y > 0 && moveValues.y < 1)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        if (moveValues.x < 0 && moveValues.x > -1 && moveValues.y < 0 && moveValues.y > -1)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 135);
        }
        if (moveValues.x > 0 && moveValues.x < 1 && moveValues.y < 0 && moveValues.y > -1)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, -135);
        }
    }*/
}
