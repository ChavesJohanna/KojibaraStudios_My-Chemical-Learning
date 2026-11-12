using UnityEngine;

public class DañarJefe : MonoBehaviour
{
    private SpriteRenderer sprite;

    private float vidaMaxima = 100f;

    private float vidaActual;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        vidaActual = vidaMaxima;
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Jugador")) //coloco al jugador como prueba
        {
            vidaActual -= 10f;

            // Evita que la vida sea menor a cero
            vidaActual = Mathf.Max(vidaActual, 0f);

            // Calcula cuánto debe volverse rojo
            float porcentajeDanio = 1f - (vidaActual / vidaMaxima);

            // Cambia el color del sprite
            sprite.color = Color.Lerp(Color.white, Color.red, porcentajeDanio);

            Debug.Log("Vida del jefe: " + vidaActual);
        }
    }
}
