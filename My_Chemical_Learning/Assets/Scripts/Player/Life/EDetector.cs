using System.Linq;
using UnityEngine;

public class EDetector : MonoBehaviour
{
    private IDamage[] damages; //obtiene a los implementan la interfaz 
                                // en este caso la barra de vida

    private void Start()
    {
        damages = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None)
        .OfType<IDamage>()
        .ToArray();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log(col.gameObject.name);

        if (col.gameObject.name == "Player") // si colisiona con el player resta la barra 
        {
            for (int i = 0; i < damages.Length; i++)
            {
                damages[i].Damage();
            }
        }


    }
}
