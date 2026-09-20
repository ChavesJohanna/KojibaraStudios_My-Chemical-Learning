using UnityEngine;
using UnityEngine.UI;

public class BotonOpciones : MonoBehaviour //se encuentra en el boton opciones del menu principal
{
    private MenuPrincipal menu;
    private Button boton;

    private void Start()
    {
        menu = transform.parent.GetComponentInParent<MenuPrincipal>();

        boton = GetComponent<Button>();
        boton.onClick.AddListener(ActivarPanel);
    }
    private void ActivarPanel()
    {
        menu.ActivarOpciones(); //activa el panel de opciones
    }
}
