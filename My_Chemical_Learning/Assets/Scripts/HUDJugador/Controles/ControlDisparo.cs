using UnityEngine;
using UnityEngine.EventSystems;

public class ControlDisparo : MonoBehaviour, IPointerDownHandler
{
    private AnimarJugador jugadorAnimacion;
    private DispararJugador jugadorDisparo;
    private void Start()
    {
        jugadorAnimacion = GameObject.FindWithTag("Jugador")?.GetComponent<AnimarJugador>();
        jugadorDisparo = GameObject.FindWithTag("Jugador")?.GetComponent<DispararJugador>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (jugadorAnimacion != null)
        {
            jugadorAnimacion.AnimarDisparo(); //ejecuta la animacion

            //prueba
            PoolElementos.Instance.ActivarElemento("Agua");
            jugadorDisparo.Disparar();
        }
    }
}
