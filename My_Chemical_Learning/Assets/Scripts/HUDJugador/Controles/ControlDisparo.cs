using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ControlDisparo : MonoBehaviour, IPointerDownHandler
{
    private AnimarJugador jugadorAnimacion;
    private DispararJugador jugadorDisparo;

    private bool puedeDisparar = true;
    private float tiempoEspera = 1f; //para evitar disparos consecutivos

    private void Start()
    {
        jugadorAnimacion = GameObject.FindWithTag("Jugador")?.GetComponent<AnimarJugador>();
        jugadorDisparo = GameObject.FindWithTag("Jugador")?.GetComponent<DispararJugador>();
    }

    public void OnPointerDown(PointerEventData eventData) //se ejecuta al tocar el boton
    {
        if (jugadorAnimacion == null)
            return; 

        if(jugadorDisparo == null) 
            return;

        if (!puedeDisparar) //si puede disparar es falso no dispara xd
            return;

        jugadorAnimacion.AnimarDisparo(); //ejecuta la animacion

        jugadorDisparo.Disparar(); //dispara el elemto correspondiente

        StartCoroutine(EsperarDisparo()); //inicia la espera para el sig disparo

    }

    private IEnumerator EsperarDisparo()
    {
        puedeDisparar = false;

        yield return new WaitForSeconds(tiempoEspera);

        puedeDisparar = true;
    }
}
