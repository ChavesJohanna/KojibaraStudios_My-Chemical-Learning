using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ControlUsar : MonoBehaviour, IPointerDownHandler //se encuentra en el boton "Usar" del hud
{
    private BarraVida barraVida;
    private Transform jugador;

    private MesaTrabajo[] mesasTrabajo; //servira para encontrar todas las mesas del nivel


    private void Start()
    {
        barraVida = GameObject.Find("BarraVida")?.GetComponent<BarraVida>();

        jugador = GameObject.FindWithTag("Jugador")?.GetComponent<Transform>();

        mesasTrabajo = FindObjectsByType<MesaTrabajo>(FindObjectsSortMode.None);



        if (GuardarPartida.HayDatosGuardados()) //revisa si hay datos guardado para recargarlos
        {

            GuardarPartida.RecuperarDatos(out Vector3 posicion, out float vida);

            jugador.position = posicion; //carga la posicion guardad del jugador

            barraVida.CargarVidaGuardada(vida); //carga la vida guardada del jugador

        }

    }
    
    public void OnPointerDown(PointerEventData eventData) //se ejecuta al tocar el boton
    {
        MesaTrabajo mesaActual = ObtenerMesaActual();

        if (mesaActual == null)
            return;
    
        Vector3 posicionJugador = jugador.transform.position;

        float vida = barraVida.VidaActual();

        GuardarPartida.GuardarDatos(posicionJugador, vida); //guardamos los datos

        GuardarNivel.GuardarNivelActual();//guarda el nivel en el que se encuentra el jugador

        Debug.Log("usando mesa");
        SceneManager.LoadScene("MesaTrabajo"); //carga la mesa de trabajo

    }

    private MesaTrabajo ObtenerMesaActual() //busca la mesa actual q esta detectando al jugador
    {
        foreach (MesaTrabajo mesa in mesasTrabajo)
        {
            if (mesa.JugadorEnMesa())
            {
                return mesa;
            }
        }

        return null;
    }
}
