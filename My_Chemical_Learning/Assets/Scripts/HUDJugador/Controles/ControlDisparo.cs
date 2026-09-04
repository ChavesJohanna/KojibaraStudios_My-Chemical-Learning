using UnityEngine;
using UnityEngine.EventSystems;

public class ControlDisparo : MonoBehaviour, IPointerDownHandler
{
    private AnimarJugador jugadorAnimacion;

    private void Start()
    {
        jugadorAnimacion = GameObject.FindWithTag("Jugador")?.GetComponent<AnimarJugador>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (jugadorAnimacion != null)
        {
            jugadorAnimacion.AnimarDisparo(); //ejecuta la animacion
        }
    }
}
