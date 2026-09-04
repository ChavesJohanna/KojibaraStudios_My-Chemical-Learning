using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour //el script se encuentra en el objeto del hud con el mismo nombre y servira de controlador
{
    private List<GameObject> hud; //los elemtos se ocultaran al estar en pausa
    private GameObject panel;
    private bool juegoPausado = false;

    private void Start()
    {
        panel = transform.Find("Panel").gameObject;
        panel.SetActive(false); //desactivar el panel por defecto

        hud = new List<GameObject>();

        for (int i = 0; i < 2; i++) //añade los hijos del hud excepto el obj "Pausa"
        {
            hud.Add(transform.parent.GetChild(i).gameObject);
        }
 
    }

    public void AbrirPanel(bool botonApretado)
    {
        juegoPausado = botonApretado;

        panel.SetActive(juegoPausado);

        Time.timeScale = juegoPausado ? 0f : 1f; //pausa y despausa el juego dependiendo si el panel esta activo o no

        for (int i = 0; i < hud.Count; i++) //desactiva los elementos al estar el panel activo
        {
            hud[i].SetActive(!juegoPausado);
        }
    }

}
