using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;

    private float smoothTime = 0.2f; // Tiempo que tarda la cámara en alcanzar al objetivo

    private Vector3 velocity;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void LateUpdate()
    {
        if (player == null) // Busca al player si no lo encontro al iniciar
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");

            if (obj != null)
                player = obj.transform;

            return;
        }

        Vector3 targetPos = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
            );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPos,
            ref velocity,
            smoothTime);
    }
}
