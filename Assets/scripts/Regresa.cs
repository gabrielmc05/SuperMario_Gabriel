using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Regresa : MonoBehaviour
{
    private UIDocument menu;
    private Button BotonRegresa; 

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;
        
        BotonRegresa = root.Q<Button>("BotonRegresar");
        BotonRegresa.clicked += Regresar;
    }

    void OnDisable()
    {
        BotonRegresa.clicked -= Regresar;
        //botonRegresa.UnregisterCallback<ClickEvent>(Regresar);
    }

    void Regresar()
    {
        SceneManager.LoadScene("Menu");
    }


}
