
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlDisparo : MonoBehaviour, IPointerDownHandler
{
    private AnimarJugador jugadorAnimacion;
    private DispararJugador jugadorDisparo;

    private float tiempoEspera = 1f; // Evita disparos consecutivos.
    private float proximoDisparo;

    private void Start()
    {
        jugadorAnimacion = GameObject.FindWithTag("Jugador")?.GetComponent<AnimarJugador>();
        jugadorDisparo = GameObject.FindWithTag("Jugador")?.GetComponent<DispararJugador>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (jugadorAnimacion == null || jugadorDisparo == null)
            return;

        if (Time.unscaledTime < proximoDisparo)
            return;

        jugadorAnimacion.AnimarDisparo();
        jugadorDisparo.Disparar();

        proximoDisparo = Time.unscaledTime + tiempoEspera;
    }
}
