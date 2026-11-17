using System.Collections;
using UnityEngine;

public class PuertaJefe : MonoBehaviour//el script se encuentra en la puesta de entradad
{
    private AtacarJefe jefeAtaque;
    private DañarJefe jefeDaño;

    private Collider2D puertaSalida;

    private void Start()
    {
        jefeAtaque = GameObject.FindWithTag("Jefe")?.GetComponent<AtacarJefe>();
        jefeDaño = GameObject.FindWithTag("Jefe")?.GetComponent<DañarJefe>();

        puertaSalida = transform.parent.Find("Salida").GetComponent<Collider2D>();
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Jugador"))
        {
            StartCoroutine(ReiniciarCol());
        }
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Jugador") && jefeDaño.Derrotado())
        {
            puertaSalida.isTrigger = true; //hacemos triger el col de la puerta de salida pa q el jugador pase
        }
    }

    private IEnumerator ReiniciarCol() //le reasinamos un collider para evitar q el jugador escape
    {
        Destroy(GetComponent<BoxCollider2D>());

        yield return null;

        gameObject.AddComponent<BoxCollider2D>();

        jefeAtaque.Atacar(); //una vez se ciera la puerta el jefe ataca
    }
}
