// using UnityEngine;

// public class animacion : MonoBehaviour
// {
//     private Rigidbody2D rb;
//     private Animator animator;
//     private SpriteRenderer sr; 
//     private EstadoPersonaje estado;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         animator = GetComponent<Animator>();
//         sr = GetComponent<SpriteRenderer>();
//         estado = GetComponentInChildren<EstadoPersonaje>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         animator.SetFloat("velocidad", Mathf.Abs(rb.linearVelocity.x));
//         sr.flipX = rb.linearVelocity.x < -0.1;
//         animator.SetBool("enPiso", estado.estaEnPiso);
//     }
// }

using UnityEngine;

public class CambiaAnimacion : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr; 
    private EstadoPersonaje estado;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        estado = GetComponentInChildren<EstadoPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("velocidad", Mathf.Abs(rb.linearVelocity.x));
        sr.flipX = rb.linearVelocity.x < -0.1;
        animator.SetBool("enPiso", estado.estaEnPiso);
    }
}
