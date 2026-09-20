using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotonReestablecer : MonoBehaviour //se encunetra en el boton reestablecer del menu de opc del menu principal
{   
    private Button boton;

    private void Start()
    {
        boton = GetComponent<Button>();
        boton.onClick.AddListener(Reestablecer);
    }

    private void Reestablecer()
    {
        Debug.Log("El volumen por defecto");
    }
}
