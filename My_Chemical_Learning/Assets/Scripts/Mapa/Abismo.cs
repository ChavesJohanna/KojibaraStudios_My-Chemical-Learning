using UnityEngine;

public class Abismo : MonoBehaviour //el script se encuantra en el tilemap del mismo nombre en la grid
{
    private Pantallas pantalla;

    private void Start()
    {
        pantalla = GameObject.Find("Pantallas")?.GetComponent<Pantallas>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Jugador")) //si el jugador coliciona activa la pantalla derrota
        {
            pantalla.PantallaDerrota();
        }
       
    }
}
