using UnityEngine;

public class BloqueNitrogeno : MonoBehaviour
{
    private Collider2D col; //se volvera uno normal una vez se detecte el bloque de sal

    private GameObject sinBloque;
    private GameObject conBloque;

    private BarraVida barraVida;

    private void Start()
    {
        col = GetComponent<Collider2D>();

        sinBloque = transform.Find("SinNitro").gameObject;
        conBloque = transform.Find("ConNitro").gameObject;

        barraVida = FindFirstObjectByType<BarraVida>();

        conBloque.SetActive(false);
        sinBloque.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Nitrogeno"))
        {
            sinBloque.SetActive(false);
            conBloque.SetActive(true);

            col.isTrigger = false;

            gameObject.layer = LayerMask.NameToLayer("Piso"); //se autoasigna al layer para q el jugador los pise
        }

        if (otro.CompareTag("Jugador") && sinBloque.activeSelf)
        {
            barraVida?.Disminuir(10f);
        }
    }
}