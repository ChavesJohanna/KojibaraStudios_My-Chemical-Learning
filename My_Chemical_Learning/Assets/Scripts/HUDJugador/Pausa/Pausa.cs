using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour //el script se encuentra en el objeto del hud con el mismo nombre y servira de controlador
{
    private List<GameObject> hud; //los elemtos se ocultaran al estar en pausa
    private GameObject panelPausa;
    private GameObject panelOpciones;

    private void Start()
    {
        panelPausa = transform.Find("PanelPausa").gameObject;
        panelPausa.SetActive(false); //desactivar el panel por defecto

        panelOpciones = transform.Find("PanelOpciones").gameObject;
        panelOpciones.SetActive(false); //desactivar el panel por defecto

        hud = new List<GameObject>();

        for (int i = 1; i < 3; i++) //añade los hijos del hud excepto el obj "Pausa"
        {
            hud.Add(transform.parent.GetChild(i).gameObject);
        }
 
    }

    public void AbrirPausa() //activa el panel de pausa y congela el juego
    {
        Time.timeScale = 0f;

        panelPausa.SetActive(true);
        panelOpciones.SetActive(false);

        MostrarHud(false);
    }

    public void ReanudarJuego() //desactiva los paneles y vuelve a activar el juego
    {
        Time.timeScale = 1f;

        panelPausa.SetActive(false);
        panelOpciones.SetActive(false);

        MostrarHud(true);
    }

    public void AbrirOpciones() //abre el panel de opciones
    {
        panelPausa.SetActive(false);
        panelOpciones.SetActive(true);
    }

    public void VolverAPausa() //cierra el panel de opciones y reactiva el panel de pausa
    {
        panelOpciones.SetActive(false);
        panelPausa.SetActive(true);
    }

    private void MostrarHud(bool mostrar) //se encarga de activar y desactivar el hud del jugador
    {
        for (int i = 0; i < hud.Count; i++)
        {
            hud[i].SetActive(mostrar);
        }
    }
}
