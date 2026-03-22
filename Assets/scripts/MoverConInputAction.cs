//Gabriel de Jesús Manzo Cuevas A01803514

using UnityEngine;
using UnityEngine.InputSystem;

// Esta clase maneja el movimiento del personaje utilizando el nuevo Input System de Unity.
// Controla el movimiento horizontal y el salto basado en acciones de input configuradas.
public class MoverConInputAction : MonoBehaviour
{
    // Acción de input para el movimiento horizontal, asignada en el inspector
    [SerializeField]
    private InputAction accionMover;

    // Acción de input para el salto, asignada en el inspector
    [SerializeField]
    private InputAction accionSaltar;

    // Referencia al Rigidbody2D para aplicar fuerzas de movimiento
    private Rigidbody2D rb;
    // Referencia al script EstadoPersonaje para verificar si puede saltar
    private EstadoPersonaje estado;

    // Velocidad horizontal del personaje
    private float velocidadX = 7f;
    // Velocidad vertical para el salto
    private float velocidadY = 7f;
        
    void Start()
    {
        // Habilita la acción de movimiento
        accionMover.Enable();
        // Obtiene la referencia al Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        // Obtiene la referencia al script EstadoPersonaje
        estado = GetComponentInChildren<EstadoPersonaje>();
    }

    void OnEnable()
    {
        // Habilita la acción de salto y suscribe el evento performed al método saltar
        accionSaltar.Enable();  //cuando se habilita, se habiliytan sus acciones
        accionSaltar.performed += saltar;
    }

    void OnDisable() //cuando está en pausa
    {
        // Deshabilita la acción de salto y desuscribe el evento
        accionSaltar.Disable(); //lo 
        accionSaltar.performed -= saltar;
    }

    public void saltar(InputAction.CallbackContext context) //quien accionó el evento, el contexto de la acción, se puede usar para saber si se mantuvo presionado o no, etc.
    {
        // Si el personaje está en el piso, aplica velocidad vertical para saltar
        if (estado.estaEnPiso)
        {
            rb.linearVelocityY = velocidadY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Lee el valor del vector de movimiento de la acción de input
        Vector2 movimiento /*vector de movimiento*/ = accionMover.ReadValue<Vector2>();
        // Aplica la velocidad horizontal al Rigidbody2D basada en el input
        rb.linearVelocityX = movimiento.x * velocidadX;
        
    }
}
