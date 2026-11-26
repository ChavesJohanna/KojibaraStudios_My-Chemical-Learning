
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //permite cargar escenas
using System.Collections; //permite utilizar Coroutine

public class BotonJugar : MonoBehaviour
{
    private Button boton; //componente del gameobject

    private Button botonPrimeraImagen; //componente del boton de la primera imagen
    private Button botonSegundaImagen; //componente del boton de la segunda imagen
    private Button botonTerceraImagen; //componente del boton de la tercera imagen

    [SerializeField] private GameObject primeraImagen; //primera imagen que se mostrara
    [SerializeField] private GameObject segundaImagen; //segunda imagen que se mostrara
    [SerializeField] private GameObject terceraImagen; //tercera imagen que se mostrara

    private string nombreNivel; //nombre de la escena

    private float delay = 0.3f; //delay que permitira que suene el boton antes de cargar el nivel

    private bool puedeContinuar = false; //evita que se cargue la escena varias veces

    private void Start()
    {
        boton = GetComponent<Button>(); //obtiene el componente del gameobject
        nombreNivel = "Nivel1";

        botonPrimeraImagen = primeraImagen.GetComponent<Button>();
        botonSegundaImagen = segundaImagen.GetComponent<Button>();
        botonTerceraImagen = terceraImagen.GetComponent<Button>();

        primeraImagen.SetActive(false);
        segundaImagen.SetActive(false);
        terceraImagen.SetActive(false);

        boton.onClick.AddListener(Jugar); //ejecuta el metodo colocado entre parentesis al clikear el boton

        botonPrimeraImagen.onClick.AddListener(MostrarSegundaImagen);
        botonSegundaImagen.onClick.AddListener(MostrarTerceraImagen);
        botonTerceraImagen.onClick.AddListener(Continuar);
    }

    private void Jugar()
    {
        GuardarPartida.ResetearDatos(); //reinicia los datos 

        boton.interactable = false; //desactiva la interacción del botón
        AudioManager.Instance.ReproducirBoton();

        primeraImagen.SetActive(true); //muestra la primera imagen
    }

    private void MostrarSegundaImagen()
    {
        AudioManager.Instance.ReproducirBoton();

        primeraImagen.SetActive(false);
        segundaImagen.SetActive(true);
    }

    private void MostrarTerceraImagen()
    {
        AudioManager.Instance.ReproducirBoton();

        segundaImagen.SetActive(false);
        terceraImagen.SetActive(true);
    }

    private void Continuar()
    {
        if (puedeContinuar)
            return;

        puedeContinuar = true;

        AudioManager.Instance.ReproducirBoton();

        terceraImagen.SetActive(false);

        StartCoroutine(CargarNivel()); //inicia la espera
    }

    private IEnumerator CargarNivel()
    {
        yield return new WaitForSeconds(delay); //espera el tiempo indicado

        SceneManager.LoadScene(nombreNivel); //carga la escena
    }
}
