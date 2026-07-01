using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BContinue : MonoBehaviour
{
    private GameObject panel;

    private Button button;

    private PauseMenu pauseMenu;

    private void Start()
    {
        panel = transform.parent.gameObject; //Tomamos el panel padre del botón

        pauseMenu = GameObject.FindGameObjectWithTag("HUD").GetComponent<PauseMenu>();

        button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            pauseMenu.ActiveHUD();

            Time.timeScale = 1f; // Reanuda el tiempo normal
            panel.SetActive(false);
            Debug.Log("Juego reanudado");
        });
    }

}
