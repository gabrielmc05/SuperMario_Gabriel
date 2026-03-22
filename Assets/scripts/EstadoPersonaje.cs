// Gabriel de Jesús Manzo Cuveas A01803514
// Este script se encarga de detectar si el personaje está en el piso o no, utilizando los métodos OnTriggerEnter2D y OnTriggerExit2D para cambiar el valor de la variable estaEnPiso. Esta variable es utilizada por otros scripts para determinar si el personaje puede saltar o no, entre otras cosas.
using UnityEngine;

public class EstadoPersonaje : MonoBehaviour  // La clase EstadoPersonaje hereda de MonoBehaviour, lo que le permite ser utilizada como un componente en un GameObject de Unity.
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
