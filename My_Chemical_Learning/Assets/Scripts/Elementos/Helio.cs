using UnityEngine;
using System.Collections;

public class Helio : MonoBehaviour, IElemento //el script se encuentra en el prefab del mismo nombre y es el que dispara el jugador
{
    private Rigidbody2D rb;
    private float velocidad = 5f;
 
    private float tiempoVida = 3f; //una vez se termine y no haya colicionado se regrese al pool
    private bool fueraPool = false; //una vez salga del pool se pondra en true y iniciara su regreso

    private Rigidbody2D rbJugador; //obtendra el rigid del jugador para agregarle el doble salto
    private float fuerzaSalto = 10f; //la cantidad de altura que le agregara al jugador

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rbJugador = GameObject.FindWithTag("Jugador")?.GetComponent<Rigidbody2D>();
    }

    public void MovimientoElemento(float direccion)
    {
        fueraPool = true;

        rb.linearVelocity = new Vector2(direccion * velocidad, 0f); // agrega un pequeño impulso al inicio

        StartCoroutine(InicioTiempoVida()); //una vez inicia su aparicion y no coliciona regresa al pool

        rbJugador.linearVelocity = new Vector2(rbJugador.linearVelocity.x, rbJugador.linearVelocity.y + fuerzaSalto);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, velocidad); //se mueve hacia arriba
    }

    private void OnTriggerEnter2D(Collider2D otro)
    { 
        if (!fueraPool) //si ya esta en el pool no se ejecute la logica de re regresarlo al pool
            return;

        if (otro.gameObject.layer == LayerMask.NameToLayer("Piso")) //si coliciona con el mapa el objeto regresa al pool
        { 
            VolverAlPool();
        }
    }

    private IEnumerator InicioTiempoVida() //sera llamado al momento de reactivarse y si no colisiona con nada
    {
        if (!fueraPool) //si ya esta en el pool no se ejecute la logica de re regresarlo al pool
            yield break;

        yield return new WaitForSeconds(tiempoVida);

        VolverAlPool();
    }

    private void VolverAlPool() //reestableze el movimiento del objeto y lo gregresa al pool
    {
        fueraPool = false;

        rb.linearVelocity = Vector2.zero;

        string nombre = gameObject.name //limpia el nombre quitandole el (clone) y espacios vacios
            .Replace("(Clone)", "")
            .Replace(" ", "")
            .Trim();


        PoolElementos.Instance.DevolverElemento(nombre, gameObject); //se envia el nombre limpio del objeto
    }

}
