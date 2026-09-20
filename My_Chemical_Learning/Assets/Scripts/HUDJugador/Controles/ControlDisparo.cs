using UnityEngine;
using UnityEngine.EventSystems;

public class ControlDisparo : MonoBehaviour, IPointerDownHandler
{
    private AnimarJugador jugadorAnimacion;
    private DispararJugador jugadorDisparo;

    private float tiempoEspera = 1f; //para evitar disparos consecutivos
    private float proximoDisparo;

    private void Start()
    {
        jugadorAnimacion = GameObject.FindWithTag("Jugador")?.GetComponent<AnimarJugador>();
        jugadorDisparo = GameObject.FindWithTag("Jugador")?.GetComponent<DispararJugador>();
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al tocar el boton
    {
        if (jugadorAnimacion == null || jugadorDisparo == null)
            return;

        if (Time.unscaledTime < proximoDisparo) //el tiempo de espera sigue avanzando aun estando en pausa
            return;

        jugadorAnimacion.AnimarDisparo(); //ejecuta la animacion

        jugadorDisparo.Disparar(); //dispara el elemto correspondiente

        proximoDisparo = Time.unscaledTime + tiempoEspera; //inicia la espera para el sig disparo

    }

}
