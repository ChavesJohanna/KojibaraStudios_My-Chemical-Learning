using UnityEngine;
using UnityEngine.U2D;

public class DispararJugador : MonoBehaviour //el script se encuentra en el gameobject "Jugador"
{
    private Rigidbody2D rb;
    private float dif = 1f; //direrencia de posicion
    private float ultimadir = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moverX = rb.linearVelocity.x;

        if (moverX > dif)
        {
            ultimadir = 1f;
        }
        else if (moverX < -dif)
        {
            ultimadir = -1f;
        }
    }

    public void Disparar()
    {
        GameObject poolElemento = PoolElementos.Instance.AsignarPosicionElemento(transform); //le asigna la posicion al elemento

        if (poolElemento == null) 
            return;
           

        IElemento elemento = poolElemento.GetComponent<IElemento>();

        elemento.MovimientoElemento(ultimadir); //le envia la direccion a la cual moverse
    }
}
