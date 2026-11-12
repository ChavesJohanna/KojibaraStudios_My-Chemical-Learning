using UnityEngine;

public class MoverManoJefe : MonoBehaviour //se encuentra en las manos del jefe que golpean al jugador
{
    private Rigidbody2D rb;

    private Vector2 posInicial;
    private Vector2 objetivo;

    private bool regresando = false;
    private bool moviendo = false;

    private float velocidad = 20f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        posInicial = rb.position;
    }

    public void MoverHacia(Vector2 direccion)
    {
        if (moviendo) return; // si se sta moviendo no puede cambiar de direccion

        objetivo = direccion;
        moviendo = true;
    }

    private void FixedUpdate()
    {
        if (!moviendo) return;

        Vector2 destino = regresando ? posInicial : objetivo; //el destino osila entre la pos inicial y el objetivo

        Vector2 nuevaPos = Vector2.MoveTowards(
            rb.position,
            destino,
            velocidad * Time.fixedDeltaTime
        );

        rb.MovePosition(nuevaPos);

        if (nuevaPos != destino) return;

        if (regresando)
        {
            regresando = false;
            moviendo = false;
            return;
        }

        regresando = true;
    }
}
