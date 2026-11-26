using TMPro;
using UnityEngine;

public class TextoVolEfectos : MonoBehaviour //se encutra en el texto del meu de opciones
{
    private TextMeshProUGUI texto;

    private void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();

        texto.text = AudioManager.Instance.ObtenerPorcentajeEfectos();
    }

    private void Update()
    {
        if (!ModificarTextoVolumen.CambiandoVolEfectos()) return;

        if (ModificarTextoVolumen.CambiandoVolEfectos())
        {
            texto.text = AudioManager.Instance.ObtenerPorcentajeEfectos(); //le asignamos el vol
        }
    }
}
