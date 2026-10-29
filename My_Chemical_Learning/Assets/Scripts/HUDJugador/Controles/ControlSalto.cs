using UnityEngine;
using UnityEngine.EventSystems;

public class ControlSalto : MonoBehaviour, IPointerDownHandler
{
    private Rigidbody2D jugador;
    private IMover tipoMovimiento;

    private void Start()
    {
        jugador = GameObject.FindWithTag("Jugador")?.GetComponent<Rigidbody2D>(); //obtine el rigid del jugador

        tipoMovimiento = gameObject?.GetComponent<IMover>(); //el boton tiene de componente el movimiento correspondiente
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al presionar el boton
    {
        if (jugador != null)
        { 
            tipoMovimiento.Mover(jugador); //mueve hacia arriba pa saltar
        }
    }
}
