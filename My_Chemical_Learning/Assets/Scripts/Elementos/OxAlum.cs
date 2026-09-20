using UnityEngine;
using System.Collections;

public class OxAlum : MonoBehaviour, IElemento //el script se encuentra en el prefab del mismo nombre y es el que dispara el jugador
{

    private Rigidbody2D rb;
    private SpriteRenderer spElemento;
    private SpriteRenderer spJugador;//obtendra el spriterendere del jugador para cambiarle el color

    private float velocidad = 5f;
    private float tiempoVida = 3f;//una vez se termine se regrese al pool

    private bool fueraPool = false; //una vez salga del pool se pondra en true y iniciara su regreso

    private Color colorJugador;
    private Color colorAlum = new Color32(188, 137, 127, 255); //color medio rojizo

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spElemento = GetComponent<SpriteRenderer>();

        spJugador = GameObject.FindWithTag("Jugador")?.GetComponent<SpriteRenderer>();
        colorJugador = spJugador.color;
    }

    public void MovimientoElemento(float direccion)
    {
        fueraPool = true;

        rb.linearVelocity = new Vector2(direccion * velocidad, 0f); // agrega un pequeño impulso al inicio

        spJugador.color = colorAlum; //pintamo al jugador
        spElemento.enabled = false; //desactivamos el sprite del obj

        StartCoroutine(InicioTiempoVida()); //una vez inicia su aparicion y termina su tiempovida regresa al pool
    }


    private IEnumerator InicioTiempoVida() //sera llamado al momento de reactivarse
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

        spJugador.color = colorJugador; //recoloreaamo al jugador
        spElemento.enabled = true; //lo activamo

        string nombre = gameObject.name //limpia el nombre quitandole el (clone) y espacios vacios
            .Replace("(Clone)", "")
            .Replace(" ", "")
            .Trim();


        PoolElementos.Instance.DevolverElemento(nombre, gameObject); //se envia el nombre limpio del objeto
    }

}
