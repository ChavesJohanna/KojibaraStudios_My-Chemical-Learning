using UnityEngine;

public class PuertaSalidaJefe : MonoBehaviour
{
    private DañarJefe jefeDaño;

    private Collider2D col;

    private void Start()
    {
        jefeDaño = GameObject.FindWithTag("Jefe")?.GetComponent<DañarJefe>();

        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D otro)
    {

        if (otro.gameObject.CompareTag("Jugador") && jefeDaño.Derrotado())
        {
            col.isTrigger = true;
        }
    }
}
