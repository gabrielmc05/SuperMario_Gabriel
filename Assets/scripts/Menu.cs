using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument menu;

    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCreditos;
    private Button buttonCloseHelp;
    private Button buttonCloseCreditos;

    private VisualElement help;
    private VisualElement creditos;
    private VisualElement botones;

    private ScrollView scrollCreditos;

    private bool creditosActivos = false;
    [SerializeField] private float velocidadCreditos = 30f;

    private void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        botonJugar = root.Q<Button>("BotonJugar");
        botonAyuda = root.Q<Button>("BotonAyuda");
        botonCreditos = root.Q<Button>("BotonCreditos");

        buttonCloseHelp = root.Q<Button>("ButtonCloseHelp");
        buttonCloseCreditos = root.Q<Button>("ButtonCloseCreditos");

        help = root.Q<VisualElement>("Help");
        creditos = root.Q<VisualElement>("Creditos");
        botones = root.Q<VisualElement>("Botones");

        scrollCreditos = root.Q<ScrollView>("ScrollCreditos");

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

        if (help != null)
            help.style.display = DisplayStyle.None;

        if (creditos != null)
            creditos.style.display = DisplayStyle.None;

        if (botones != null)
            botones.style.display = DisplayStyle.Flex;

        creditosActivos = false;
    }

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

    private void Update()
    {
        if (!creditosActivos || scrollCreditos == null)
            return;

        Vector2 offset = scrollCreditos.scrollOffset;
        offset.y += velocidadCreditos * Time.deltaTime;
        scrollCreditos.scrollOffset = offset;

        float maxY = scrollCreditos.contentContainer.layout.height - scrollCreditos.layout.height;

        if (maxY > 0 && scrollCreditos.scrollOffset.y >= maxY)
        {
            scrollCreditos.scrollOffset = Vector2.zero;
        }
    }

    private void AbrirJugar(ClickEvent evt)
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void MostrarAyuda(ClickEvent evt)
    {
        if (help != null)
            help.style.display = DisplayStyle.Flex;

        if (botones != null)
            botones.style.display = DisplayStyle.None;
    }

    private void CerrarAyuda(ClickEvent evt)
    {
        if (help != null)
            help.style.display = DisplayStyle.None;

        if (botones != null)
            botones.style.display = DisplayStyle.Flex;
    }

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

    private void CerrarCreditos(ClickEvent evt)
    {
        if (creditos != null)
            creditos.style.display = DisplayStyle.None;

        if (botones != null)
            botones.style.display = DisplayStyle.Flex;

        creditosActivos = false;
    }
}