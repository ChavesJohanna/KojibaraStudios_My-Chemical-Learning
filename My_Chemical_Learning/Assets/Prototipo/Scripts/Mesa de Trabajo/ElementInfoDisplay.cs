
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementInfoDisplay : MonoBehaviour
{
    public static ElementInfoDisplay Instance { get; private set; }

    [Tooltip("Arrastra aqui el TextMeshProUGUI que mostrara la informacion")]
    [SerializeField] private TextMeshProUGUI infoText;

    private Dictionary<ChemElementType, string> info =
        new Dictionary<ChemElementType, string>()
    {
        {
            ChemElementType.Hidrogeno,
            "<b>Hidrogeno (H)</b>\n" +
            "Numero atomico: 1\n" +
            "Es el elemento mas ligero y abundante del universo.\n" +
            "Forma parte del agua y de numerosos compuestos.\n\n" +
            "<color=#FFD166>Pista:</color> Combina dos atomos de hidrogeno con uno de oxigeno para formar agua."
        },
        {
            ChemElementType.Oxigeno,
            "<b>Oxigeno (O)</b>\n" +
            "Numero atomico: 8\n" +
            "Es un gas esencial para la respiracion y numerosos procesos quimicos.\n\n" +
            "<color=#FFD166>Pista:</color> Participa en la formacion de agua y oxidos metalicos."
        },
        {
            ChemElementType.Oxigeno3,
            "<b>Oxigeno x3 (O3)</b>\n" +
            "Representa tres atomos de oxigeno agrupados para una combinacion.\n\n" +
            "<color=#FFD166>Pista:</color> Busca dos atomos de aluminio para formar oxido de aluminio (Al2O3)."
        },
        {
            ChemElementType.Helio,
            "<b>Helio (He)</b>\n" +
            "Numero atomico: 2\n" +
            "Es un gas noble, muy liviano y poco reactivo.\n" +
            "Se utiliza en globos y aplicaciones especiales.\n\n" +
            "<color=#FFD166>Pista:</color> Puedes combinarlo con el espacio vacio para usarlo... Quizas te ayude a llegar más alto."
        },
        {
            ChemElementType.Sodio,
            "<b>Sodio (Na)</b>\n" +
            "Numero atomico: 11\n" +
            "Es un metal alcalino muy reactivo.\n\n" +
            "<color=#FFD166>Pista:</color> Combinado con cloro forma cloruro de sodio, conocido como sal comun.\n" +
            "Puede hacer bloques bastante duros."
        },
        {
            ChemElementType.Cloro,
            "<b>Cloro (Cl)</b>\n" +
            "Numero atomico: 17\n" +
            "Es un halogeno que puede formar distintos compuestos quimicos.\n\n" +
            "<color=#FFD166>Pista:</color> Puede combinarse con sodio para formar sal o con hidrogeno para formar acido clorhidrico."
        },
        {
            ChemElementType.Cobre,
            "<b>Cobre (Cu)</b>\n" +
            "Numero atomico: 29\n" +
            "Es un metal rojizo y excelente conductor de electricidad y calor.\n" +
            "Se utiliza en cables, circuitos y componentes electronicos.\n" +
            "Hay bastante de esto en tu interior, V.E.G.A."
        },
        {
            ChemElementType.Calcio,
            "<b>Calcio (Ca)</b>\n" +
            "Numero atomico: 20\n" +
            "Es un elemento importante para la formacion de huesos y dientes.\n" +
            "Es el metal más abundante del ser humano.\n" +
            "Tambien participa en numerosos procesos biologicos."
        },
        {
            ChemElementType.Carbono,
            "<b>Carbono (C)</b>\n" +
            "Numero atomico: 6\n" +
            "Es fundamental para la vida y forma parte de numerosas moleculas organicas.\n\n" +
            "<color=#FFD166>Pista:</color> Combinado con dos atomos de oxigeno puede formar dioxido de carbono."
        },
        {
            ChemElementType.Nitrogeno,
            "<b>Nitrogeno (N)</b>\n" +
            "Numero atomico: 7\n" +
            "Es uno de los principales componentes de la atmosfera terrestre.\n" +
            "<color=#FFD166>Pista:</color> Dos atomos de nitrogeno pueden unirse para formar nitrogeno molecular (N2). Tal vez puedas congelar el agua con ésto."
        },
        {
            ChemElementType.Aluminio,
            "<b>Aluminio (Al)</b>\n" +
            "Numero atomico: 13\n" +
            "Es un metal ligero y resistente utilizado en estructuras, envases y transporte.\n\n" +
            "<color=#FFD166>Pista:</color> Puede agruparse con otro atomo de aluminio y combinarse con tres atomos de oxigeno."
        },
        {
            ChemElementType.Aluminio2,
            "<b>Aluminio x2 (Al2)</b>\n" +
            "Representa dos atomos de aluminio agrupados para una combinacion.\n\n" +
            "<color=#FFD166>Pista:</color> Busca tres atomos de oxigeno para formar oxido de aluminio (Al2O3)."
        },
        {
            ChemElementType.Vacio,
            "<b>Espacio vacio</b>\n" +
            "No representa un elemento quimico. Es un objeto especial de la mesa de trabajo.\n\n" +
            "<color=#FFD166>Pista:</color> Puedes combinarlo con helio para descubrir este elemento."
        }
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
            return;

        infoText.text = info.TryGetValue(tipo, out string texto)
            ? texto
            : "Elemento sin informacion cargada.";
    }
}
