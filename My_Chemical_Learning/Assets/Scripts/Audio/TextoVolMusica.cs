using TMPro;
using UnityEngine;

public class TextoVolMusica : MonoBehaviour//se encutra en el texto del meu de opciones
{
    private TextMeshProUGUI texto;

    private void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();

        texto.text = AudioManager.Instance.ObtenerPorcentajeMusica();
    }

    private void Update()
    {
        if (!ModificarTextoVolumen.CambiandoVolMusica()) return;

        if (ModificarTextoVolumen.CambiandoVolMusica())
        {
            texto.text = AudioManager.Instance.ObtenerPorcentajeMusica(); //le asignamos el vol
        }
    }
}
