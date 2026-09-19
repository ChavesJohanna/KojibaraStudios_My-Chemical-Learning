using UnityEngine;

public class BloqueNitrogeno : MonoBehaviour
{
    private Collider2D col; //se volvera uno normal una vez se detecte el bloque de sal

    private GameObject sinBloque;
    private GameObject conBloque;


    private void Start()
    {
        col = GetComponent<Collider2D>();

        sinBloque = transform.Find("SinNitro").gameObject;
        conBloque = transform.Find("ConNitro").gameObject;

        conBloque.SetActive(false);
        sinBloque.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D otro)
    {
        Debug.Log("Algo entró al trigger: " + otro.gameObject.name);

        if (otro.gameObject.CompareTag("Nitrogeno"))
        {
            sinBloque.SetActive(false);
            conBloque.SetActive(true);
            Debug.Log("colicion de la zona detectado");

            col.isTrigger = false;

            gameObject.layer = LayerMask.NameToLayer("Piso"); //se autoagigna al layer para q el jugador los pise
        }
    }
}
