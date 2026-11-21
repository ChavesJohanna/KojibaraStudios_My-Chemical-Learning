using System.Collections;
using UnityEngine;

public class PuertaEntradaJefe : MonoBehaviour//el script se encuentra en la puesta de entradad
{
    private AtacarJefe jefeAtaque;

    private bool atacando = false;

    private void Start()
    {
        jefeAtaque = GameObject.FindWithTag("Jefe")?.GetComponent<AtacarJefe>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (atacando) return; //evitamos que se reejecute la corrutina

        if (otro.gameObject.CompareTag("Jugador"))
        {
            StartCoroutine(ReiniciarCol());
        }
    }

    private IEnumerator ReiniciarCol() //le reasinamos un collider para evitar q el jugador escape
    {
        Destroy(GetComponent<BoxCollider2D>());

        yield return null;

        gameObject.AddComponent<BoxCollider2D>();

        atacando = true;

        jefeAtaque.Atacar(); //una vez se ciera la puerta el jefe ataca
    }
}
