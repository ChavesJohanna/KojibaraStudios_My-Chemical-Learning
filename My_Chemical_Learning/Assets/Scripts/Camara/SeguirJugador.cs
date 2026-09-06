using UnityEngine;

public class SeguirJugador : MonoBehaviour
{
    private Transform jugador;
    private float smoothTime = 0.2f; //ti9empo que tarda la cámara en alcanzar al jugador
    private Vector3 velocity;

    private void Start()
    {
        jugador = GameObject.FindWithTag("Jugador")?.transform;
    }

    private void LateUpdate()
    {
        if (jugador == null) //busca al jugador si no lo encontro al iniciar
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");

            if (obj != null)
                jugador = obj.transform;

            return;
        }

        Vector3 targetPos = new Vector3(
            jugador.position.x,
            jugador.position.y,
            transform.position.z
            );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime);
    }
}
