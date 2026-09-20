using UnityEngine;
using System.Collections;

public class Sal : MonoBehaviour, IElemento //el script se encuentra en el prefab del mismo nombre y es el que dispara el jugador
{
    private Rigidbody2D rb;
    private float velocidad = 5f;

    private float tiempoVida = 3f; //una vez se termine y no haya colicionado se regrese al pool
    private bool fueraPool = false; //una vez salga del pool se pondra en true y iniciara su regreso

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovimientoElemento(float direccion)
    {
        this.fueraPool = true;

        rb.linearVelocity = new Vector2(direccion * velocidad, 0f); // agrega un pequeño impulso al inicio

        StartCoroutine(InicioTiempoVida()); //una vez inicia su aparicion y no coliciona regresa al pool
    }

    private void OnTriggerEnter2D(Collider2D otro)
    { 
        if (!fueraPool) //si ya esta en el pool no se ejecute la logica de re regresarlo al pool
            return;

        bool esPiso = otro.gameObject.layer == LayerMask.NameToLayer("Piso"); //si coliciona con el mapa
        bool esZona = otro.gameObject.CompareTag("BloqueSal"); //si choca en las zonas

        if (esPiso || esZona) //regresa al pool
            VolverAlPool();
    }

    private IEnumerator InicioTiempoVida() //sera llamado al momento de reactivarse y si no colisiona con nada
    {
        if (!fueraPool) //si ya esta en el pool no se ejecute la logica de re regresarlo al pool
            yield break;

        yield return new WaitForSeconds(tiempoVida);

        VolverAlPool();
    }

    private void VolverAlPool() //reestableze algunas variables y regresa el obj al pool
    {
        this.fueraPool = false;

        PoolElementos.Instance.DevolverElemento(this.gameObject); //se envia el obj
    }

}
