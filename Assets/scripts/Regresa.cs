// Gabriel de Jesús Manzo Cuevas A0803514

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

// Maneja el boton de regreso para volver al menu principal.
public class Regresa : MonoBehaviour
{
    // Referencia al documento de UI Toolkit
    private UIDocument menu;
    // Referencia al botón de regresar
    private Button BotonRegresa; 

    // Obtiene el boton de UI Toolkit y suscribe su accion.
    void OnEnable()
    {
        // Obtiene el UIDocument y la raíz
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;
        
        // Busca el botón por nombre
        BotonRegresa = root.Q<Button>("BotonRegresar");
        // Suscribe el evento clicked al método Regresar
        BotonRegresa.clicked += Regresar;
    }

    // Desuscribe el evento al desactivar para evitar referencias colgantes.
    void OnDisable()
    {
        // Desuscribe el evento clicked
        BotonRegresa.clicked -= Regresar;
        //botonRegresa.UnregisterCallback<ClickEvent>(Regresar);
    }

    // Carga la escena del menu.
    void Regresar()
    {
        // Carga la escena llamada "Menu"
        SceneManager.LoadScene("Menu");
    }


}
