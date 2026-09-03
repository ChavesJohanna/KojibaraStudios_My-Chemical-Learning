using UnityEngine;
using UnityEngine.EventSystems;

public class ControlMovimiento : MonoBehaviour, IPointerDownHandler, IPointerUpHandler //el script se encuentra en los botones de movimiento del jugador
{
    private Rigidbody2D jugador;
    private IMover tipoMovimiento;
    private bool estaPulsado = false;

    private void Start()
    {
        jugador = GameObject.FindWithTag("Jugador")?.GetComponent<Rigidbody2D>(); //obtine el rigid del jugador

        tipoMovimiento = gameObject?.GetComponent<IMover>(); //el boton tiene de componente el movimiento correspondiente
    }

    private void FixedUpdate()
    {
        if (jugador != null && estaPulsado) 
        {
            tipoMovimiento.Mover(jugador);
        }

    }

    public void OnPointerDown(PointerEventData eventData)//se ejecuta al precionar el boton
    {
        estaPulsado = true;
    }

    public void OnPointerUp(PointerEventData eventData) //se ejecuta al soltar el boton
    {
        estaPulsado = false;

        jugador.linearVelocity = new Vector2 (0f, jugador.linearVelocity.y); //detiene el movimiento del jugador
    }
}

