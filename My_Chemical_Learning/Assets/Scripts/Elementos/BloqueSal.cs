using UnityEngine;

public class BloqueSal : MonoBehaviour
{
    private GameObject sinBloque;
    private GameObject conBloque;


    private void Awake()
    {
        sinBloque = transform.Find("SinBloque").gameObject;
        conBloque = transform.Find("ConBloque").gameObject;
    }


    private void OnTriggerEnter2D(Collider2D otro)
    {
        Debug.Log("Algo entró al trigger: " + otro.gameObject.name);

        if (otro.gameObject.name == "Sal(Clone)")
        {
            sinBloque.SetActive(false);
            conBloque.SetActive(true);
Debug.Log("colicion de la zona detectado");
        }
    }
}
