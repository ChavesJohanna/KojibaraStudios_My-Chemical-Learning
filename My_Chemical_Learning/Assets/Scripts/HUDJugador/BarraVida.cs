using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private Image barraLlena;

    private float vidaMaxima = 100f;
    private float vidaMinima = 0f;
    private float vidaActual = 100f;

    private Pantallas pantalla;

    private void Start()
    {
        barraLlena = transform.Find("Completa").GetComponent<Image>();
        pantalla = GameObject.Find("Pantallas")?.GetComponent<Pantallas>();

        if (GuardarPartida.HayDatosGuardados())
        {
            GuardarPartida.RecuperarDatos(out Vector3 posicion, out float vida);
            CargarVidaGuardada(vida);
        }
        else
        {
            barraLlena.fillAmount = vidaActual / vidaMaxima;
        }

        // Cura al jugador si acaba de regresar de la mesa.
        if (CuracionMesaTrabajo.DebeCurar)
        {
            Curar(45f);
            CuracionMesaTrabajo.DebeCurar = false;
        }
    }

    public void Disminuir(float daño = 10f)
    {
        vidaActual = Mathf.Clamp(vidaActual - daño, vidaMinima, vidaMaxima);
        barraLlena.fillAmount = vidaActual / vidaMaxima;

        if (vidaActual <= vidaMinima)
        {
            pantalla?.PantallaDerrota();
        }
    }

    public void Curar(float cantidad)
    {
        vidaActual = Mathf.Clamp(vidaActual + cantidad, vidaMinima, vidaMaxima);
        barraLlena.fillAmount = vidaActual / vidaMaxima;
    }

    public float VidaActual()
    {
        return vidaActual;
    }

    public void CargarVidaGuardada(float nuevaVida)
    {
        vidaActual = Mathf.Clamp(nuevaVida, vidaMinima, vidaMaxima);
        barraLlena.fillAmount = vidaActual / vidaMaxima;
    }
}