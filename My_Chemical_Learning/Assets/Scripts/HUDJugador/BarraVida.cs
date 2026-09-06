using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour //se ecuentra en el objeto con el mismo nombre del hud del jugador
{
    private Image barraLlena;

    private float vidaMaxima = 100f;
    private float vidaMinima = 25f;

    private float vidaActual = 100f;

    private Pantallas pantalla;

    private void Start()
    {
        barraLlena = transform.Find("Completa").GetComponent<Image>();

        pantalla = GameObject.Find("Pantallas")?.GetComponent<Pantallas>();

        if (GuardarPartida.HayDatosGuardados())
        {
            GuardarPartida.RecuperarDatos(out Vector3 posicion, out float vida);
            CargarVidaGuardada(vida); // refresca la barra inmediatamente
        }
        else
        {
            // Si no hay datos guardados, inicializa con vidaActual
            barraLlena.fillAmount = vidaActual / vidaMaxima;
        }
    }

    public void Disminuir()
    {
        float daño = 10f;

        vidaActual = Mathf.Clamp(vidaActual - daño, vidaMinima, vidaMaxima); //limita la vida para que no se pase

        barraLlena.fillAmount = vidaActual / vidaMaxima; //va borrando la imagen con la vida maxima

        if (vidaActual <= vidaMinima) //si se acaba la vida se abre la pantalla derrota
        {
            pantalla.PantallaDerrota();
        }
    }

    public float VidaActual() //para que se guarde en el checkpoint
    {
        return vidaActual;
    }

    public void CargarVidaGuardada(float nuevaVida)
    {
        vidaActual = Mathf.Clamp(nuevaVida, vidaMinima, vidaMaxima);

        barraLlena.fillAmount = vidaActual / vidaMaxima;
    }
}
