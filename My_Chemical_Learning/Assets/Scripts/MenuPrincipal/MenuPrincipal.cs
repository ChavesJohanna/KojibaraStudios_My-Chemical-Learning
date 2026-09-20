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

    public void AbrirMenu()
    {
        panelOpciones.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void AbrirOpciones()
    {
        panelMenu.SetActive(false);
        panelOpciones.SetActive(true);
    }
}
