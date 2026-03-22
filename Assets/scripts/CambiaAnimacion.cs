// Gabriel de Jesús Manzo Cuevas A0803514

using UnityEngine;

// Esta clase se encarga de cambiar las animaciones del personaje basado en su velocidad y dirección de movimiento,
// así como en su estado (si está en el piso o no). Utiliza el Animator para controlar las transiciones de animación
// y el SpriteRenderer para voltear el sprite horizontalmente según la dirección del movimiento.
public class CambiaAnimacion : MonoBehaviour
{
    // Referencia al componente Rigidbody2D del personaje para acceder a su velocidad lineal
    private Rigidbody2D rb;
    // Referencia al componente Animator para controlar las animaciones
    private Animator animator;
    // Referencia al componente SpriteRenderer para voltear el sprite
    private SpriteRenderer sr; 
    // Referencia al script EstadoPersonaje para saber si el personaje está en el piso
    private EstadoPersonaje estado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Obtiene la referencia al Rigidbody2D del mismo GameObject
        rb = GetComponent<Rigidbody2D>();
        // Obtiene la referencia al Animator del mismo GameObject
        animator = GetComponent<Animator>();
        // Obtiene la referencia al SpriteRenderer del mismo GameObject
        sr = GetComponent<SpriteRenderer>();
        // Obtiene la referencia al script EstadoPersonaje en los hijos del GameObject
        estado = GetComponentInChildren<EstadoPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        // Establece el parámetro "velocidad" en el Animator con el valor absoluto de la velocidad horizontal
        // Esto controla la animación de caminar/correr basada en la velocidad
        animator.SetFloat("velocidad", Mathf.Abs(rb.linearVelocity.x));
        // Voltea el sprite horizontalmente si la velocidad en x es negativa (movimiento hacia la izquierda)
        sr.flipX = rb.linearVelocity.x < -0.1;
        // Establece el parámetro "enPiso" en el Animator basado en si el personaje está en el piso
        animator.SetBool("enPiso", estado.estaEnPiso);
    }
}
