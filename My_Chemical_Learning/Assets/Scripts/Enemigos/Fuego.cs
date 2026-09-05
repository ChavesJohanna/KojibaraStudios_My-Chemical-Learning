using UnityEngine;

public class Fuego : MonoBehaviour //el script se encuentra en el obstaculo con el mismo nombre
{
    private float vida = 10f;

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.gameObject.CompareTag("Agua"))
        {
            vida -= 5f;

            if (vida <= 0) //si la vida es cero se desactiva el objeto
                gameObject.SetActive(false);
        }
    }
}
