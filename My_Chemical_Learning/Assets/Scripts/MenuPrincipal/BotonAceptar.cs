using UnityEngine;
using UnityEngine.UI;

public class BotonAceptar : MonoBehaviour //se encuentra en el boton aceptar del menu de opciones del menu principal
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
        menu.ActivarMenu(); //activa el menu 
    }
}
