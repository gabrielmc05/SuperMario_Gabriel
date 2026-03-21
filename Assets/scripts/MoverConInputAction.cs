// using UnityEngine;
// using UnityEngine.InputSystem;

// public class mover : MonoBehaviour
// {
//     [SerializeField]

//     private InputAction accionMover;

//     [SerializeField]
//     private InputAction accionSaltar;


//     private Rigidbody2D rb;

//     private float velocidadX = 7f;
//     private float velocidadY = 7f;
        
//     void Start()
//     {
//         accionMover.Enable();
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void OnEnable()
//     {
//         accionSaltar.Enable();  //cuando se habilita, se habiliytan sus acciones
//         accionSaltar.performed += saltar;
//     }

//     void OnDisable() //cuando está en pausa
//     {
//         accionSaltar.Disable(); //lo 
//         accionSaltar.performed -= saltar;
//     }

//     public void saltar(InputAction.CallbackContext context) //quien accionó el evento, el contexto de la acción, se puede usar para saber si se mantuvo presionado o no, etc.
//     {
//         rb.linearVelocityY = velocidadY;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         Vector2 movimiento /*vector de movimiento*/ = accionMover.ReadValue<Vector2>();
//         //transform.position = (Vector2)transform.position + Time.deltaTime * velocidadX * movimiento;
//         rb.linearVelocityX = movimiento.x * velocidadX;
//     }
// }
using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField]

    private InputAction accionMover;

    [SerializeField]
    private InputAction accionSaltar;


    private Rigidbody2D rb;
    private EstadoPersonaje estado;

    private float velocidadX = 7f;
    private float velocidadY = 7f;
        
    void Start()
    {
        accionMover.Enable();
        rb = GetComponent<Rigidbody2D>();
        estado = GetComponentInChildren<EstadoPersonaje>();
    }

    void OnEnable()
    {
        accionSaltar.Enable();  //cuando se habilita, se habiliytan sus acciones
        accionSaltar.performed += saltar;
    }

    void OnDisable() //cuando está en pausa
    {
        accionSaltar.Disable(); //lo 
        accionSaltar.performed -= saltar;
    }

    public void saltar(InputAction.CallbackContext context) //quien accionó el evento, el contexto de la acción, se puede usar para saber si se mantuvo presionado o no, etc.
    {
        if (estado.estaEnPiso)
        {
            rb.linearVelocityY = velocidadY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movimiento /*vector de movimiento*/ = accionMover.ReadValue<Vector2>();
        //transform.position = (Vector2)transform.position + Time.deltaTime * velocidadX * movimiento;
        rb.linearVelocityX = movimiento.x * velocidadX;
        
    }
}
