using UnityEngine;
using UnityEngine.UI;

public class ReestablecerPausa : MonoBehaviour //se encuentra en el boton reestableer del menu opc que esta en el men de pausa
{
    private Button boton;

    private void Start()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(Reestablecer);
    }

    private void Reestablecer()
    {
        Debug.Log("El volumen por defecto dentro del menu de pausa");
    }
}
