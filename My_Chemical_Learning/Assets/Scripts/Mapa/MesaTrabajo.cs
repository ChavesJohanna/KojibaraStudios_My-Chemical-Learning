using UnityEngine;

public class MesaTrabajo : MonoBehaviour
{
    private GameObject cartel; //la imagen que aparece al detectar al jugador cerca

    private bool jugadorEnMesa = false; //con esto le avisaremos al boton "Usar" si la mesa esta por usarse

    private void Start()
    {
        cartel = transform.GetChild(0).gameObject;

        cartel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Jugador"))
        {
            cartel.SetActive(true); //activamos el cartel

            jugadorEnMesa = true; //si detecta al jugador que el botn ya pueda usarse
        }
    }
    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Jugador"))
        {
            cartel.SetActive(false); //desactivamos el cartel

            jugadorEnMesa = false; //si el jugador sale 
        }
    }

    public bool JugadorEnMesa()
    {
        return jugadorEnMesa;
    }
}
