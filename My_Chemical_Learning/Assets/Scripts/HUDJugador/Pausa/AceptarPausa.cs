using UnityEngine;
using UnityEngine.UI;

public class AceptarPausa : MonoBehaviour //se encuentra en el boton aceptar de las opciones del menu de pausa
{
    private Button boton;
    private Pausa pausa;

    private void Start()
    {
        pausa = transform.parent.GetComponentInParent<Pausa>();

        boton = GetComponent<Button>();
        boton.onClick.AddListener(ActivarPanel);
    }

    private void ActivarPanel()
    {
        pausa.VolverAPausa(); //desactiva el panel de opc y muestra el de pausa
        
    }
}
