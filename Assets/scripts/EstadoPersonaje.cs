using UnityEngine;

public class EstadoPersonaje : MonoBehaviour
{
    public bool estaEnPiso {get; private set;} = false;  //C# implementa el get y set de manera predefinida, en esto caso cambiamos el set a private para que solo se pueda modificar desde esta clase, y el get es público para que otras clases puedan leer su valor. El valor inicial es false porque el personaje empieza en el aire.

    void OnTriggerEnter2D(Collider2D collision)
    {
        estaEnPiso = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        estaEnPiso = false;
        print(estaEnPiso);
    }
}
