using UnityEngine;

public class FinNivel : MonoBehaviour //el script se encuentra en el objeto con el mismo nombre
{
    private Pantallas pantalla;

    private void Start()
    {
        pantalla = GameObject.Find("Pantallas")?.GetComponent<Pantallas>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Jugador")) //si el jugador coliciona activa la pantalla victoria
        {
            pantalla.PantallaVictoria();
        }

    }
}
