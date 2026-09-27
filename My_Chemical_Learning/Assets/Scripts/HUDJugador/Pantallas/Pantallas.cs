using System.Collections.Generic;
using UnityEngine;

public class Pantallas : MonoBehaviour // Se encuentra en el objeto con el mismo nombre del HUD del jugador
{
    private List<GameObject> hud; // Los elementos se ocultarán al ganar/perder el nivel

    private int objsHUD = 4; // Cantidad de elementos que tiene el HUD para desactivarlos

    private GameObject victoria;
    private GameObject derrota;

    private void Start()
    {
        hud = new List<GameObject>();

        for (int i = 0; i < objsHUD; i++) // Añade los hijos del HUD excepto el objeto "Pantallas"
        {
            hud.Add(transform.parent.GetChild(i).gameObject);
        }

        victoria = transform.Find("Victoria").gameObject;
        derrota = transform.Find("Derrota").gameObject;

        victoria.SetActive(false);
        derrota.SetActive(false);
    }

    public void PantallaVictoria()
    {
        if (victoria.activeSelf || derrota.activeSelf) // Si alguna ya está activa, no se activa la otra
            return;

        victoria.SetActive(true);

        // Reproduce la música de victoria
        AudioManager.Instance.ReproducirVictoria();

        DesactivarHUD();
    }

    public void PantallaDerrota()
    {
        if (victoria.activeSelf || derrota.activeSelf)
            return;

        derrota.SetActive(true);

        // Reproduce la música de derrota
        AudioManager.Instance.ReproducirDerrota();

        DesactivarHUD();
    }

    private void DesactivarHUD()
    {
        for (int i = 0; i < hud.Count; i++) // Desactiva los elementos al estar el panel activo
        {
            hud[i].SetActive(false);
        }
    }
}