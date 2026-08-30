using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementInfoDisplay : MonoBehaviour
{
    public static ElementInfoDisplay Instance { get; private set; }

    [Tooltip("Arrastrá acá el TextMeshProUGUI que va a mostrar la info")]
    public TextMeshProUGUI infoText; //

    private Dictionary<ChemElementType, string> info = new Dictionary<ChemElementType, string>()
    {
        { ChemElementType.Hidrogeno, "<b>Hidrógeno (H)</b>\nNúmero atómico: 1\nEl elemento más simple y abundante del universo. Forma parte del agua (H2O)." },
        { ChemElementType.Oxigeno,   "<b>Oxígeno (O)</b>\nNúmero atómico: 8\nGas esencial para respirar. Forma parte del aire y del agua." },
        { ChemElementType.Helio,     "<b>Helio (He)</b>\nNúmero atómico: 2\nGas noble muy liviano, no reacciona con otros elementos. Se usa en globos." },
        { ChemElementType.Sodio,     "<b>Sodio (Na)</b>\nNúmero atómico: 11\nMetal muy reactivo. Combinado con cloro forma la sal común." },
        { ChemElementType.Cloro,     "<b>Cloro (Cl)</b>\nNúmero atómico: 17\nGas tóxico en estado puro, pero combinado forma la sal de mesa (NaCl)." },
        { ChemElementType.Cobre,     "<b>Cobre (Cu)</b>\nNúmero atómico: 29\nMetal rojizo, excelente conductor de electricidad. Se usa en cables." },
        { ChemElementType.Calcio,    "<b>Calcio (Ca)</b>\nNúmero atómico: 20\nMetal esencial para huesos y dientes. Se encuentra en la leche y sus derivados." },
        { ChemElementType.Carbono,   "<b>Carbono (C)</b>\nNúmero atómico: 6\nBase de la vida: forma parte de todos los seres vivos, del ADN y de moléculas orgánicas." },
    };

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void MostrarInfo(ChemElementType tipo)
    {
        if (infoText == null)
        {
            Debug.LogWarning("ElementInfoDisplay: falta asignar el infoText en el Inspector.");
            return;
        }

        infoText.text = info.TryGetValue(tipo, out string texto)
            ? texto
            : "Elemento sin información cargada.";
    }
}