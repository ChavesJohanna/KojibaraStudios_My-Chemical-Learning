using UnityEngine;

public class MenuPrincipal : MonoBehaviour //se encuentra en el objeto con el mismo nombre
{
    private GameObject panelMenu;
    private GameObject panelOpciones;

    private void Start()
    {
        panelMenu = transform.Find("PanelMenu").gameObject;
        panelOpciones = transform.Find("PanelOpciones").gameObject;

        panelMenu.SetActive(true);
        panelOpciones.SetActive(false);
    }

    public void ActivarMenu()
    {
        panelOpciones.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void ActivarOpciones()
    {
        panelMenu.SetActive(false);
        panelOpciones.SetActive(true);
    }
}
