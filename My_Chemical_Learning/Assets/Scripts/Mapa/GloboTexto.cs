
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GloboTexto : MonoBehaviour
{
    [Header("Identificación")]
    [SerializeField] private string idDialogo;

    [Header("Elementos visuales")]
    [SerializeField] private Canvas canvas;
    [SerializeField] private TMP_Text texto;
    [SerializeField] private string mensaje;

    [Header("Audio")]
    [SerializeField] private AudioClip audioDialogo;

    [Header("Configuración")]
    [SerializeField] private float tiempoDesaparicion = 3f;

    private SpriteRenderer spriteRenderer;
    private bool audioReproducido;
    private bool jugadorDentro;
    private string idCompleto;

    private Coroutine corrutinaDesaparicion;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Identifica el diálogo según la escena.
        idCompleto = SceneManager.GetActiveScene().name + "_" + idDialogo;

        // Comprueba si el audio ya fue reproducido.
        audioReproducido = RegistroDialogos.YaSeReprodujo(idCompleto);

        // Oculta el globo inicialmente.
        OcultarGlobo();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Jugador"))
            return;

        jugadorDentro = true;

        // Cancela la desaparición si el jugador vuelve a entrar.
        if (corrutinaDesaparicion != null)
        {
            StopCoroutine(corrutinaDesaparicion);
            corrutinaDesaparicion = null;
        }

        // Actualiza y muestra el mensaje.
        texto.text = mensaje;
        MostrarGlobo();

        // Reproduce el audio únicamente la primera vez.
        if (!audioReproducido)
        {
            audioReproducido = true;
            RegistroDialogos.Registrar(idCompleto);

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.ReproducirDialogo(audioDialogo);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Jugador"))
            return;

        jugadorDentro = false;

        // Comienza la cuenta regresiva al salir.
        if (corrutinaDesaparicion != null)
        {
            StopCoroutine(corrutinaDesaparicion);
        }

        corrutinaDesaparicion = StartCoroutine(EsperarParaOcultar());
    }

    private IEnumerator EsperarParaOcultar()
    {
        yield return new WaitForSeconds(tiempoDesaparicion);

        if (!jugadorDentro)
        {
            OcultarGlobo();
        }

        corrutinaDesaparicion = null;
    }

    private void MostrarGlobo()
    {
        spriteRenderer.enabled = true;
        canvas.gameObject.SetActive(true);
    }

    private void OcultarGlobo()
    {
        spriteRenderer.enabled = false;
        canvas.gameObject.SetActive(false);
    }
}
