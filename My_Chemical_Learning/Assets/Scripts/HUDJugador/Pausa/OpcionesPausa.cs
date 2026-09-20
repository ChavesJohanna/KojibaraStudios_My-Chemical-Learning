using UnityEngine;
using UnityEngine.UI;

public class OpcionesPausa : MonoBehaviour
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
        pausa.AbrirOpciones(); //abre el panel de pausa
    }
}
