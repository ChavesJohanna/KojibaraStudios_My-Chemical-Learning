using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
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

        barraLlena.fillAmount = vidaActual / vidaMaxima;

        /*if (GuardarPartida.HayDatosGuardados())
        {
            GuardarPartida.RecuperarDatos(out Vector3 posicion);//, out float vida);
            //CargarVidaGuardada(vida);
        }
        else
        {
            barraLlena.fillAmount = vidaActual / vidaMaxima;
            
        }*/

    }

    public void Disminuir()
    {
        float danio = 10f;

        vidaActual = Mathf.Clamp(vidaActual - danio, vidaMinima, vidaMaxima);
        barraLlena.fillAmount = vidaActual / vidaMaxima;

        if (vidaActual <= vidaMinima)
        {
            pantalla?.PantallaDerrota();
        }
    }


    public float VidaActual()
    {
        return vidaActual;
    }

    /*public void CargarVidaGuardada(float nuevaVida)
    {
        vidaActual = Mathf.Clamp(nuevaVida, vidaMinima, vidaMaxima);
        barraLlena.fillAmount = vidaActual / vidaMaxima;
    }*/
}