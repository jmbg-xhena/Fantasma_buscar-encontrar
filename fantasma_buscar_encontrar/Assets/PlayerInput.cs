using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInput : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public InputAction Input_moveP1;
    private Vector3 moveValuesP1;
    public InputAction Input_moveP2;
    private Vector3 moveValuesP2;
    public float velocidadMovimiento=0.1f;

    private void OnEnable()
    {
        Input_moveP1.Enable();
        Input_moveP2.Enable();
    }

    private void OnDisable()
    {
        Input_moveP1.Disable();
        Input_moveP2.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveValuesP1 = new Vector3(Input_moveP1.ReadValue<Vector2>().x, Input_moveP1.ReadValue<Vector2>().y, 0f);
        P1.transform.position += moveValuesP1*velocidadMovimiento;

        moveValuesP2 = new Vector3(Input_moveP2.ReadValue<Vector2>().x, Input_moveP2.ReadValue<Vector2>().y, 0f);
        P2.transform.position += moveValuesP2 * velocidadMovimiento;
    }
}
