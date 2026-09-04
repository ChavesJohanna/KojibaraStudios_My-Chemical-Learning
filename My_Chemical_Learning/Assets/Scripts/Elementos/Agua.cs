using Unity.VisualScripting;
using UnityEngine;

public class Agua : MonoBehaviour, IElemento
{
    private Rigidbody2D rb;
    private float velocidad = 5f;
    private float dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MovimientoElemento(float direccion)
    {
        this.dir = direccion;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir * velocidad, 0f); //se mueve hacia la direccion recibida
    }

}
