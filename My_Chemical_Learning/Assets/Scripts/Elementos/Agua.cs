using UnityEngine;
using System.Collections;

public class Agua : MonoBehaviour, IElemento
{
    private Rigidbody2D rb;
    private float velocidad = 5f;
    private float dir;

    private float tiempoVida = 3f; //una vez se termine y no haya colicionado se regrese al pool
    private bool fueraPool = false; //una vez salga del pool se pondra en true y iniciara su regreso

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovimientoElemento(float direccion)
    {
        this.dir = direccion;

        fueraPool = true;

        StartCoroutine(InicioTiempoVida()); //una vez inicia su aparicion y no coliciona regresa al pool
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir * velocidad, 0f); //se mueve hacia la direccion recibida
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
