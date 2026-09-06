using System.Collections.Generic;
using UnityEngine;

public class Pantallas : MonoBehaviour //se ecuentra en el objeto con el mismo nombre del hud del jugador
{
    private List<GameObject> hud; //los elemtos se ocultaran al ganar/perder el nivel

    private int objsHUD = 4; //la cantidad de elementos que tiene el hud para desactivarlos

    private GameObject victoria;
    private GameObject derrota;

    private void Start()
    {
        hud = new List<GameObject>();

        for (int i = 0; i < objsHUD; i++) //añade los hijos del hud excepto el obj "Pantallas"
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
        if (victoria.activeSelf || derrota.activeSelf) //si alguna ya esta activa no se ectiva la otra
            return;

        victoria.SetActive(true);

        DesactivarHUD();
    }

    public void PantallaDerrota()
    {
        if (victoria.activeSelf || derrota.activeSelf)
            return;

        derrota.SetActive(true);

        DesactivarHUD();
    }

    private void DesactivarHUD()
    {
        for (int i = 0; i < hud.Count; i++) //desactiva los elementos al estar el panel activo
        {
            hud[i].SetActive(false);
        }
    }
}
