// Gabriel de Jesús Manzo Cuevas A0803514
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

// Esta clase maneja la interfaz de usuario del menú principal del juego, incluyendo botones para jugar,
// mostrar ayuda, mostrar créditos, y cerrar estas secciones. También controla el scroll automático de los créditos.
public class Menu : MonoBehaviour
{
    // Referencia al documento de UI Toolkit
    private UIDocument menu;

    // Botones del menú principal
    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCreditos;
    // Botones para cerrar las secciones de ayuda y créditos
    private Button buttonCloseHelp;
    private Button buttonCloseCreditos;

    // Elementos visuales para las secciones
    private VisualElement help;
    private VisualElement creditos;
    private VisualElement botones;

    // ScrollView para los créditos
    private ScrollView scrollCreditos;

    // Bandera para saber si los créditos están activos
    private bool creditosActivos = false;
    // Velocidad de scroll de los créditos, editable en el inspector
    [SerializeField] private float velocidadCreditos = 30f;

    // Se llama cuando el script se habilita, inicializa las referencias a los elementos de UI y registra los eventos de los botones
    private void OnEnable()
    {
        // Obtiene el UIDocument y la raíz del árbol visual
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        // Busca y asigna los botones por nombre
        botonJugar = root.Q<Button>("BotonJugar");
        botonAyuda = root.Q<Button>("BotonAyuda");
        botonCreditos = root.Q<Button>("BotonCreditos");

        buttonCloseHelp = root.Q<Button>("ButtonCloseHelp");
        buttonCloseCreditos = root.Q<Button>("ButtonCloseCreditos");

        // Busca los elementos visuales
        help = root.Q<VisualElement>("Help");
        creditos = root.Q<VisualElement>("Creditos");
        botones = root.Q<VisualElement>("Botones");

        scrollCreditos = root.Q<ScrollView>("ScrollCreditos");

        // Registra los callbacks para los clicks de los botones, verificando que no sean null
        if (botonJugar != null)
            botonJugar.RegisterCallback<ClickEvent>(AbrirJugar);

        if (botonAyuda != null)
            botonAyuda.RegisterCallback<ClickEvent>(MostrarAyuda);

        if (botonCreditos != null)
            botonCreditos.RegisterCallback<ClickEvent>(MostrarCreditos);

        if (buttonCloseHelp != null)
            buttonCloseHelp.RegisterCallback<ClickEvent>(CerrarAyuda);

        if (buttonCloseCreditos != null)
            buttonCloseCreditos.RegisterCallback<ClickEvent>(CerrarCreditos);

        // Inicializa la visibilidad: oculta ayuda y créditos, muestra botones
        if (help != null)
            help.style.display = DisplayStyle.None;

        if (creditos != null)
            creditos.style.display = DisplayStyle.None;

        if (botones != null)
            botones.style.display = DisplayStyle.Flex;

        creditosActivos = false;
    }

    // Se llama cuando el script se deshabilita, desregistra los eventos para evitar memory leaks
    private void OnDisable()
    {
        if (botonJugar != null)
            botonJugar.UnregisterCallback<ClickEvent>(AbrirJugar);

        if (botonAyuda != null)
            botonAyuda.UnregisterCallback<ClickEvent>(MostrarAyuda);

        if (botonCreditos != null)
            botonCreditos.UnregisterCallback<ClickEvent>(MostrarCreditos);

        if (buttonCloseHelp != null)
            buttonCloseHelp.UnregisterCallback<ClickEvent>(CerrarAyuda);

        if (buttonCloseCreditos != null)
            buttonCloseCreditos.UnregisterCallback<ClickEvent>(CerrarCreditos);
    }

    // Se llama cada frame, maneja el scroll automático de los créditos si están activos
    private void Update()
    {
        // Si los créditos no están activos o no hay ScrollView, no hace nada
        if (!creditosActivos || scrollCreditos == null)
            return;

        // Obtiene el offset actual del scroll
        Vector2 offset = scrollCreditos.scrollOffset;
        // Incrementa el offset en y basado en la velocidad y el tiempo
        offset.y += velocidadCreditos * Time.deltaTime;
        scrollCreditos.scrollOffset = offset;

        // Calcula la posición máxima de scroll
        float maxY = scrollCreditos.contentContainer.layout.height - scrollCreditos.layout.height;

        // Si ha llegado al final, reinicia el scroll
        if (maxY > 0 && scrollCreditos.scrollOffset.y >= maxY)
        {
            scrollCreditos.scrollOffset = Vector2.zero;
        }
    }

    // Método llamado al hacer click en el botón de jugar, carga la escena del juego
    private void AbrirJugar(ClickEvent evt)
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Muestra la sección de ayuda y oculta los botones principales
    private void MostrarAyuda(ClickEvent evt)
    {
        if (help != null)
            help.style.display = DisplayStyle.Flex;

        if (botones != null)
            botones.style.display = DisplayStyle.None;
    }

    // Oculta la sección de ayuda y muestra los botones principales
    private void CerrarAyuda(ClickEvent evt)
    {
        if (help != null)
            help.style.display = DisplayStyle.None;

        if (botones != null)
            botones.style.display = DisplayStyle.Flex;
    }

    // Muestra la sección de créditos, oculta botones, reinicia scroll y activa el scroll automático
    private void MostrarCreditos(ClickEvent evt)
    {
        if (creditos != null)
            creditos.style.display = DisplayStyle.Flex;

        if (botones != null)
            botones.style.display = DisplayStyle.None;

        if (scrollCreditos != null)
            scrollCreditos.scrollOffset = Vector2.zero;

        creditosActivos = true;
    }

    // Oculta la sección de créditos, muestra botones y desactiva el scroll automático
    private void CerrarCreditos(ClickEvent evt)
    {
        if (creditos != null)
            creditos.style.display = DisplayStyle.None;

        if (botones != null)
            botones.style.display = DisplayStyle.Flex;

        creditosActivos = false;
    }
}